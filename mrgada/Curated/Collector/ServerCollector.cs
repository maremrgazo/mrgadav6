#pragma warning disable CS8981 // suppress naming rule violation
#pragma warning disable CS8618 // suppress non-null value when exiting constructor
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

public static partial class mrgada
{
    public class ServerCollector
    {
        protected readonly string _name;
        private readonly int _port;
        private volatile bool _started = false;

        private TcpListener tcpl_listener;

        private List<TcpClient> _clients = new List<TcpClient>();
        private readonly object _clientsLock = new object();

        // -- Replace Thread references with Task & CancellationToken --
        private Task _taskClientConnect;
        private Task _taskClientDisconnect;
        private Task _taskClientListener;

        private CancellationTokenSource _cts;

        private bool b_clientConnect;
        private readonly int _clientConnectThreadTimeoutMilliseconds = 100;

        private bool b_clientListener;
        private readonly int _clientListenerThreadTimeoutMilliseconds = 50;

        private bool b_clientDisconnect;
        private readonly int _clientDisconnectThreadTimeoutMilliseconds = 500;

        public ServerCollector
        (
            string name,
            int port,
            int clientConnectThreadTimeoutMilliseconds = 100,
            int clientListenerThreadTimeoutMilliseconds = 50,
            int clientDisconnectThreadTimeoutMilliseconds = 500
        )
        {
            _name = name;
            _port = port;

            _clientConnectThreadTimeoutMilliseconds = clientConnectThreadTimeoutMilliseconds;
            _clientListenerThreadTimeoutMilliseconds = clientListenerThreadTimeoutMilliseconds;
            _clientDisconnectThreadTimeoutMilliseconds = clientDisconnectThreadTimeoutMilliseconds;

            mrgada.AddServerCollector(this);
        }

        public bool Started => _started;
        public bool Stopped => !_started;

        protected virtual void OnClientConnected(TcpClient client) { }
        protected virtual void OnClientDisconnected(TcpClient client) { }
        protected virtual void OnRecieved(TcpClient client, byte[] data) { } // on server receive message from client
        protected virtual void OnStart() { }
        protected virtual void OnStop() { }

        public void Broadcast(byte[] data)  // send message to all clients
        {
            if (_clients.Count <= 0 || Stopped) return;

            lock (_clientsLock)
            {
                foreach (TcpClient client in _clients)
                {
                    try
                    {
                        NetworkStream ns_stream = client.GetStream();
                        ns_stream.Write(data, 0, data.Length);
                    }
                    catch
                    {
                        Log.Information($"{_name} ServerCollector: Client disconnected while broadcasting!");
                    }
                }
            }
        }

        // ----------------------------------------------------------------
        // Start: create a TcpListener, spawn tasks for connect/disconnect/listener
        // ----------------------------------------------------------------
        public void Start()
        {
            tcpl_listener = new TcpListener(IPAddress.Parse(mrgada._serverIp), _port);
            tcpl_listener.Start();

            // We'll use a CancellationTokenSource to coordinate stopping
            _cts = new CancellationTokenSource();

            // Enable flags so the tasks keep running
            b_clientConnect = true;
            b_clientDisconnect = true;
            b_clientListener = true;

            // Run tasks asynchronously
            _taskClientConnect = Task.Run(() => ClientConnectLoop(_cts.Token));
            _taskClientDisconnect = Task.Run(() => ClientDisconnectLoop(_cts.Token));
            _taskClientListener = Task.Run(() => ClientListenerLoop(_cts.Token));

            _started = true;
            OnStart();

            Log.Information($"{_name} ServerCollector: started!");
        }

        // ----------------------------------------------------------------
        // Stop: turn off booleans, cancel tasks, wait for them to finish
        // ----------------------------------------------------------------
        public void Stop()
        {
            // Signal loops to exit
            b_clientConnect = false;
            b_clientDisconnect = false;
            b_clientListener = false;

            // Cancel the token to wake up any Task.Delay
            _cts.Cancel();

            // Wait for tasks to complete
            Task.WaitAll(_taskClientConnect, _taskClientDisconnect, _taskClientListener);

            // Stop TcpListener
            tcpl_listener.Stop();

            _started = false;
            OnStop();

            Log.Information($"{_name} ServerCollector: stopped!");
        }

        // ------------------------------------------------
        // Connect loop (replaces ClientConnectThread)
        // ------------------------------------------------
        private async Task ClientConnectLoop(CancellationToken token)
        {
            while (b_clientConnect && !token.IsCancellationRequested)
            {
                try
                {
                    if (tcpl_listener.Pending())
                    {
                        TcpClient? client = tcpl_listener.AcceptTcpClient(); // synchronous accept

                        if (client != null)
                        {
                            string clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                            if (_clientNodes.Any(node => node.Ip == clientIp))
                            {
                                lock (_clientsLock)
                                {
                                    _clients.Add(client);
                                    Log.Information(
                                        $"{_name} ServerCollector, client connected: '{_clientNodes.FirstOrDefault(n => n.Ip == clientIp)?.Name}', " +
                                        $"number of connected clients: '{_clients.Count}'"
                                    );
                                }
                                OnClientConnected(client);
                            }
                            else
                            {
                                client.Dispose();
                            }
                        }
                    }
                }
                catch (SocketException e)
                {
                    // Expected when shutting down
                    Log.Information($"{_name} ServerCollector: exception in ClientConnectLoop: {e}");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"{_name} ServerCollector: exception in ClientConnectLoop");
                }

                // Instead of Thread.Sleep
                try
                {
                    await Task.Delay(_clientConnectThreadTimeoutMilliseconds, token);
                }
                catch (TaskCanceledException) { /* ignore */ }
            }
        }

        // ------------------------------------------------
        // Disconnect loop (replaces ClientDisconnectThread)
        // ------------------------------------------------
        private async Task ClientDisconnectLoop(CancellationToken token)
        {
            while (b_clientDisconnect && !token.IsCancellationRequested)
            {
                try
                {
                    lock (_clientsLock)
                    {
                        if (_clients.Count > 0)
                        {
                            for (int i = _clients.Count - 1; i >= 0; i--)
                            {
                                TcpClient client = _clients[i];

                                if (!IsClientConnected(client))
                                {
                                    string clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                                    Log.Information(
                                        $"{_name} ServerCollector, client disconnected: '{_clientNodes.FirstOrDefault(n => n.Ip == clientIp)?.Name}', " +
                                        $"number of connected clients: '{_clients.Count}'"
                                    );
                                    _clients.RemoveAt(i);
                                    client.Close();
                                    OnClientDisconnected(client);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"{_name} ServerCollector: exception in ClientDisconnectLoop");
                }

                try
                {
                    await Task.Delay(_clientDisconnectThreadTimeoutMilliseconds, token);
                }
                catch (TaskCanceledException) { /* ignore */ }
            }
        }

        // ------------------------------------------------
        // Listener loop (replaces ClientListenerThread)
        // ------------------------------------------------
        private async Task ClientListenerLoop(CancellationToken token)
        {
            while (b_clientListener && !token.IsCancellationRequested)
            {
                try
                {
                    lock (_clientsLock)
                    {
                        foreach (var client in _clients)
                        {
                            try
                            {
                                if (client.Available > 0)  // Check if data is available
                                {
                                    NetworkStream ns_stream = client.GetStream();
                                    byte[] data = new byte[client.Available];
                                    int bytesRead = ns_stream.Read(data, 0, data.Length);

                                    if (bytesRead > 0)
                                    {
                                        OnRecieved(client, data);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Information($"{_name} ServerCollector: exception in ClientListenerLoop (inner): {ex}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"{_name} ServerCollector: exception in ClientListenerLoop (outer)");
                }

                try
                {
                    await Task.Delay(_clientListenerThreadTimeoutMilliseconds, token);
                }
                catch (TaskCanceledException) { /* ignore */ }
            }
        }

        // -----------------------------------------------
        // Check if a client is connected
        // -----------------------------------------------
        private bool IsClientConnected(TcpClient client)
        {
            try
            {
                return !(client.Client.Poll(1, SelectMode.SelectRead) && client.Client.Available == 0);
            }
            catch (SocketException e)
            {
                Log.Information($"{_name} ServerCollector: exception in IsClientConnected: {e}");
                return false;
            }
        }
    }
}
