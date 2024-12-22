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
    public class ClientCollector
    {
        protected readonly string _name;
        private readonly int _port;
        protected bool _started = false;
        protected volatile bool _connected = false;

        private volatile TcpClient _tcpClient;
        private volatile NetworkStream _networkStream;

        // REPLACE threads with Tasks
        private Task? _taskConnectHandler;
        private Task? _taskReceiveHandler;

        private CancellationTokenSource? _cts;

        private bool b_receiveHandler;
        private bool b_connectHandler;

        private readonly int _receiveThreadTimeoutMilliseconds;
        protected readonly int _connectHandlerTimeoutMilliseconds;

        public bool Started => _started;
        public bool Stopped => !_started;

        public bool Connected => _connected;
        public bool Disconnected => !_connected;

        // If you're using _clientNodeName in logging, ensure it's defined somewhere:
        private readonly string _clientNodeName = "ClientNodeName"; // or pull from config

        public ClientCollector(string name, int serverPort, int connectHandlerTimeoutMilliseconds = 3000, int receiveThreadTimeoutMilliseconds = 50)
        {
            _name = name;
            _port = serverPort;
            _connectHandlerTimeoutMilliseconds = connectHandlerTimeoutMilliseconds;
            _receiveThreadTimeoutMilliseconds = receiveThreadTimeoutMilliseconds;

            mrgada.AddClientCollector(this);
        }

        protected virtual void OnConnect() { }
        protected virtual void OnDisconnect() { }
        protected virtual void OnRecieved(byte[] data) { }
        protected virtual void OnStart() { }
        protected virtual void OnStop() { }

        public void Send(byte[] data)
        {
            if (Disconnected || Stopped) return;
            try
            {
                _networkStream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Log.Warning($"{_name}: ClientCollector, exception in Send {ex}");
            }
        }

        // ---------------------------------------------------------------
        // Start: create tasks for connect loop & receive loop
        // ---------------------------------------------------------------
        public void Start()
        {
            // Create a CancellationTokenSource
            _cts = new CancellationTokenSource();

            // Signal the loops to keep running
            b_connectHandler = true;
            b_receiveHandler = true;

            // Fire up tasks
            _taskConnectHandler = Task.Run(() => ConnectLoop(_cts.Token));
            _taskReceiveHandler = Task.Run(() => ReceiveLoop(_cts.Token));

            OnStart();
            Log.Information($"{_name} ClientCollector {_clientNodeName}: started!");
            _started = true;
        }

        // ---------------------------------------------------------------
        // Stop: cancel tasks, wait for them, close streams
        // ---------------------------------------------------------------
        public void Stop()
        {
            // Signal loops to stop
            b_connectHandler = false;
            b_receiveHandler = false;

            // Cancel the token (this helps any Task.Delay to wake immediately)
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            // Wait for tasks to complete
            if (_taskConnectHandler != null && _taskReceiveHandler != null)
            {
                try
                {
                    Task.WaitAll(_taskConnectHandler, _taskReceiveHandler);
                }
                catch (AggregateException ex)
                {
                    foreach (var inner in ex.InnerExceptions)
                    {
                        if (inner is TaskCanceledException)
                            continue; // normal on shutdown
                        Log.Warning($"{_name} ClientCollector: Task exception in Stop(): {inner.Message}");
                    }
                }
            }

            // Close network resources
            _networkStream?.Close();
            _tcpClient?.Close();

            OnStop();
            Log.Information($"{_name} ClientCollector: stopped!");
            _started = false;
        }

        // ---------------------------------------------------------------
        // Asynchronous connect loop (replaces ConnectThread)
        // ---------------------------------------------------------------
        private async Task ConnectLoop(CancellationToken token)
        {
            while (b_connectHandler && !token.IsCancellationRequested)
            {
                try
                {
                    if (!_connected)
                    {
                        // Attempt connection
                        _tcpClient = new TcpClient();
                        _tcpClient.Connect(IPAddress.Parse(mrgada._serverIp), _port);

                        _networkStream = _tcpClient.GetStream();
                        _connected = true;

                        OnConnect();

                        // Keep-alive check loop until disconnected
                        while (_connected && b_connectHandler && !token.IsCancellationRequested)
                        {
                            try
                            {
                                _networkStream.Write(new byte[0], 0, 0);
                                // Instead of Thread.Sleep, we use async delay
                                await Task.Delay(_connectHandlerTimeoutMilliseconds, token);
                            }
                            catch
                            {
                                OnDisconnect();
                                _connected = false;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    Log.Information($"{_name} ClientCollector: retry connection in ~{_connectHandlerTimeoutMilliseconds / 1000.0:F2}s");
                    _connected = false;

                    // Wait before next connect attempt
                    try
                    {
                        await Task.Delay(_connectHandlerTimeoutMilliseconds, token);
                    }
                    catch (TaskCanceledException)
                    {
                        // normal on shutdown
                    }
                }
            }
        }

        // ---------------------------------------------------------------
        // Asynchronous receive loop (replaces ReceiveThread)
        // ---------------------------------------------------------------
        private async Task ReceiveLoop(CancellationToken token)
        {
            while (b_receiveHandler && !token.IsCancellationRequested)
            {
                try
                {
                    if (_connected && _tcpClient.Available > 0)
                    {
                        byte[] buffer = new byte[_tcpClient.Available];
                        int bytesRead = _networkStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            OnRecieved(buffer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Warning($"{_name} ClientCollector: exception in ReceiveLoop: {ex.Message}");
                }

                // Instead of Thread.Sleep(...)
                try
                {
                    await Task.Delay(_receiveThreadTimeoutMilliseconds, token);
                }
                catch (TaskCanceledException)
                {
                    // normal on shutdown
                }
            }
        }
    }
}
