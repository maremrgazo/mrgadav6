#pragma warning disable CS8981 // suppress naming rule violation
#pragma warning disable CS8618 // suppress non-null value when exiting constructor
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

using S7.Net;
using Serilog;
using SerilogTimings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static mrgada;

public static partial class mrgada
{
    public class S7ClientCollector : ClientCollector
    {
        private readonly List<mrgada.S7Db> _s7PlcDbs;

        private List<byte> _send = new List<byte>();
        private readonly object o_sendLock = new();

        // REPLACE Thread with Task
        private Task? _taskSend;
        private CancellationTokenSource? _ctsSend;

        private bool b_send;
        private int i_sendTimeout = 50;

        private bool _plcConnected = false;
        public bool PlcConnected => _plcConnected;

        public S7ClientCollector(string name, int port, List<mrgada.S7Db> s7PlcDbs)
            : base(name, port)
        {
            _s7PlcDbs = s7PlcDbs;
        }

        public void AddToSendQueue(byte[] data)
        {
            lock (o_sendLock)
            {
                _send.AddRange(data);
            }
        }

        // ---------------------------------------------------
        // OnStart: spin up the sending task
        // ---------------------------------------------------
        protected override void OnStart()
        {
            base.OnStart(); // Call base logic first (which starts connect/receive tasks)

            // Start your custom send loop
            b_send = true;
            _ctsSend = new CancellationTokenSource();

            // Fire up the send loop as an async Task
            _taskSend = Task.Run(() => SendLoop(_ctsSend.Token));
        }

        // ---------------------------------------------------
        // OnStop: cancel the sending task & wait for it
        // ---------------------------------------------------
        protected override void OnStop()
        {
            b_send = false;

            // Cancel the token to break out of Task.Delay etc.
            if (_ctsSend != null && !_ctsSend.IsCancellationRequested)
            {
                _ctsSend.Cancel();
            }

            // Wait for the task to complete
            if (_taskSend != null)
            {
                try
                {
                    _taskSend.Wait();
                }
                catch (AggregateException ex)
                {
                    // If the task was canceled, it's normal on shutdown
                    foreach (var inner in ex.InnerExceptions)
                    {
                        if (inner is TaskCanceledException)
                            continue; // ignore
                        Log.Error(inner, $"{_name} S7ClientCollector: Task exception in OnStop.");
                    }
                }
            }

            base.OnStop(); // Call base logic last (closes streams, etc.)
        }

        // ---------------------------------------------------
        // SendLoop replaces the old SendThread
        // ---------------------------------------------------
        private async Task SendLoop(CancellationToken token)
        {
            while (b_send && !token.IsCancellationRequested)
            {
                try
                {
                    if (_connected)
                    {
                        lock (o_sendLock)
                        {
                            if (_send.Count > 0)
                            {
                                List<byte> _finalSend = new List<byte>();

                                // Insert the total size at the front
                                Int32 chunkLength = sizeof(Int32) + _send.Count;
                                _send.InsertRange(0, BitConverter.GetBytes(chunkLength));

                                _finalSend.AddRange(_send);
                                _send.Clear();

                                Send(_finalSend.ToArray());
                            }
                        }
                        // Instead of Thread.Sleep, use await Task.Delay
                        try
                        {
                            await Task.Delay(i_sendTimeout, token);
                        }
                        catch (TaskCanceledException)
                        {
                            // normal on shutdown
                        }
                    }
                    else
                    {
                        // If not connected, wait for next retry
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
                catch (Exception ex)
                {
                    Log.Error(ex, $"{_name} S7ClientCollector: exception in SendLoop");
                }
            }
        }

        // ---------------------------------------------------
        // Example: override OnRecieved to process data
        // ---------------------------------------------------
        protected override void OnRecieved(byte[] data)
        {
            Int32 broadcastLength = BitConverter.ToInt32(data, 0);
            bool isPartial = data.Length != broadcastLength;

            Log.Information($"{mrgada.ClientNodeName}: Client received Broadcast, len ({data.Length}) from S7 ServerCollector: {_name}");

            int i = sizeof(Int32);
            while (i < data.Length)
            {
                short i16_chunkLength = BitConverter.ToInt16(data, i);
                short i16_dbNumber = BitConverter.ToInt16(data, i + sizeof(Int16));

                byte[] ba_dbBytes = new byte[i16_chunkLength - (sizeof(Int16) + sizeof(Int16))];
                Buffer.BlockCopy(data, i + sizeof(Int16) + sizeof(Int16), ba_dbBytes, 0, ba_dbBytes.Length);

                foreach (mrgada.S7Db s7Db in _s7PlcDbs)
                {
                    if (s7Db.Num == i16_dbNumber)
                    {
                        s7Db.SetBytes(ba_dbBytes);
                        s7Db.ParseCVs();

                        Log.Information($"  Client chunk, db ({i16_dbNumber}), len ({ba_dbBytes.Length}) from S7 Collector: {_name}");

                        // Get last 10 bytes of db and log
                        int lengthToTake = Math.Min(10, ba_dbBytes.Length);
                        byte[] lastBytes = new byte[lengthToTake];
                        Array.Copy(ba_dbBytes, ba_dbBytes.Length - lengthToTake, lastBytes, 0, lengthToTake);
                        string s_lastBytes = BitConverter.ToString(lastBytes).Replace("-", " ");
                        Log.Information($"      Last ~ 10 bytes are: {s_lastBytes}");

                        break;
                    }
                }
                i += i16_chunkLength;
            }
        }
    }
}
