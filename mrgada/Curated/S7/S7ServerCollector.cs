﻿#pragma warning disable CS8981 // suppress naming rule violation
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
    public class S7ServerCollector : ServerCollector
    {
        private List<byte> _s7broadcast = new List<byte>();

        private readonly S7.Net.Plc _s7Plc;
        private readonly List<mrgada.S7Db> _s7PlcDbs;

        private readonly int _readBroadcastProcessThreadMinIntervalMilliseconds;
        private Stopwatch _readBroadcastProcessThreadTimer = Stopwatch.StartNew();

        // Replacing the Thread with a Task and a CancellationToken
        private Task? _taskReadBroadcastProcess;
        private CancellationTokenSource? _cts;

        private bool b_readBroadcastProcess;
        private bool _plcConnected = false;
        public bool PlcConnected => _plcConnected;

        public S7ServerCollector(
            string name,
            int port,
            S7.Net.Plc s7Plc,
            List<mrgada.S7Db> s7PlcDbs,
            int readBroadcastProcessThreadMinIntervalMilliseconds = 50
        )
            : base(name, port)
        {
            _s7Plc = s7Plc;
            _s7PlcDbs = s7PlcDbs;
            _readBroadcastProcessThreadMinIntervalMilliseconds = readBroadcastProcessThreadMinIntervalMilliseconds;
        }

        // -------------------------------------------------
        // Called when the ServerCollector base starts
        // -------------------------------------------------
        protected override void OnStart()
        {
            // Start your custom "read & broadcast" task
            b_readBroadcastProcess = true;

            // Create a CancellationTokenSource
            _cts = new CancellationTokenSource();

            // Run the loop in an async Task
            _taskReadBroadcastProcess = Task.Run(() => ReadBroadcastProcessLoop(_cts.Token));
        }

        // -------------------------------------------------
        // Called when the ServerCollector base stops
        // -------------------------------------------------
        protected override void OnStop()
        {
            // Signal loop to stop
            b_readBroadcastProcess = false;

            // Cancel the token to break out of any Task.Delay
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            // Wait for the task to finish
            if (_taskReadBroadcastProcess != null)
            {
                try
                {
                    _taskReadBroadcastProcess.Wait();
                }
                catch (AggregateException ex)
                {
                    // If the task was canceled, just ignore the exception
                    foreach (var inner in ex.InnerExceptions)
                    {
                        if (inner is TaskCanceledException)
                            continue;
                        Log.Error(inner, $"{_name} S7ServerCollector: Task exception during stop.");
                    }
                }
            }
        }

        protected override void OnClientConnected(TcpClient client)
        {
            foreach (mrgada.S7Db s7Db in _s7PlcDbs)
                s7Db.OnClientConnect();
        }

        protected override void OnRecieved(TcpClient Client, byte[] Buffer)
        {
            Int32 chunkLength = BitConverter.ToInt32(Buffer, 0);
            int i = sizeof(Int32);
            while (i < chunkLength)
            {
                UInt16 dbNum = BitConverter.ToUInt16(Buffer, i);
                i += sizeof(UInt16);

                UInt32 bitOffset = BitConverter.ToUInt32(Buffer, i);
                i += sizeof(UInt32);

                byte s7VarBitLength = Buffer[i];
                i += sizeof(byte);

                byte[] cvBytes;
                if (s7VarBitLength == 1)
                {
                    cvBytes = new byte[1];
                    Array.Copy(Buffer, i, cvBytes, 0, 1);
                }
                else
                {
                    cvBytes = new byte[s7VarBitLength / 8];
                    Array.Copy(Buffer, i, cvBytes, 0, s7VarBitLength / 8);
                }

                if (s7VarBitLength == 1)
                {
                    bool cv = (cvBytes[0] & (1 << (int)(bitOffset % 8))) != 0;
                    _s7Plc.WriteBit(S7.Net.DataType.DataBlock, dbNum, (int)(bitOffset / 8), (int)(bitOffset % 8), cv);
                }
                else
                {
                    _s7Plc.WriteBytes(S7.Net.DataType.DataBlock, dbNum, (int)(bitOffset / 8), cvBytes);
                }

                i += s7VarBitLength;
            }
            string clientIp = ((IPEndPoint)Client.Client.RemoteEndPoint).Address.ToString();
            Log.Information($"{_name} S7ServerCollector: Received data from S7ClientCollector {_clientNodes.FirstOrDefault(n => n.Ip == clientIp)?.Name}");
        }

        // -----------------------------------------------------------
        // Now an ASYNC loop that runs until b_readBroadcastProcess==false or token canceled
        // -----------------------------------------------------------
        private async Task ReadBroadcastProcessLoop(CancellationToken token)
        {
            while (b_readBroadcastProcess && !token.IsCancellationRequested)
            {
                try
                {
                    _readBroadcastProcessThreadTimer.Restart();

                    if (_s7Plc.IsConnected)
                    {
                        _plcConnected = true;

                        using (Operation.Time($"{_name} S7ServerCollector: Reading bytes from S7 PLC"))
                        {
                            // 1) Read from PLC
                            foreach (mrgada.S7Db s7Db in _s7PlcDbs)
                            {
                                var bytesRead = _s7Plc.ReadBytes(S7.Net.DataType.DataBlock, s7Db.Num, 0, s7Db.Len);
                                s7Db.SetBytes(bytesRead);
                                s7Db.ParseCVs();
                            }

                            // 2) Prepare broadcast
                            foreach (mrgada.S7Db s7Db in _s7PlcDbs)
                            {
                                if (s7Db.BroadcastFlag)
                                {
                                    byte[] dbNum = BitConverter.GetBytes((short)s7Db.Num);
                                    byte[] chunkLength = BitConverter.GetBytes
                                    (
                                        (short)(sizeof(short) + sizeof(short) + s7Db.Bytes.Length)
                                    );

                                    _s7broadcast.AddRange(chunkLength);
                                    _s7broadcast.AddRange(dbNum);
                                    _s7broadcast.AddRange(s7Db.Bytes);

                                    s7Db.ResetBroadcastFlag();
                                }
                            }

                            // 3) Broadcast if needed
                            if (_s7broadcast.Count > 0)
                            {
                                // add broadcast length
                                Int32 broadcastLength = sizeof(Int32) + _s7broadcast.Count;
                                _s7broadcast.InsertRange(0, BitConverter.GetBytes(broadcastLength));

                                // convert to array and broadcast
                                Broadcast(_s7broadcast.ToArray());
                                _s7broadcast.Clear();
                            }
                        }

                        _readBroadcastProcessThreadTimer.Stop();

                        // Wait the remaining time if needed
                        int remainingTime = (int)(_readBroadcastProcessThreadMinIntervalMilliseconds
                                                  - _readBroadcastProcessThreadTimer.ElapsedMilliseconds);
                        if (remainingTime > 0)
                        {
                            // Replace Thread.Sleep(...) with an async delay
                            try
                            {
                                await Task.Delay(remainingTime, token);
                            }
                            catch (TaskCanceledException)
                            {
                                // normal when stopping
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            // Attempt to reconnect to PLC
                            foreach (mrgada.S7Db s7Db in _s7PlcDbs)
                            {
                                s7Db.SetBroadcastFlag();
                            }
                            _s7Plc.Open();
                        }
                        catch
                        {
                            Log.Information($"{_name} S7ServerCollector Can't connect to S7 PLC, retry in 3 seconds");
                            try
                            {
                                await Task.Delay(3000, token);
                            }
                            catch (TaskCanceledException)
                            {
                                // normal on shutdown
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"{_name} S7ServerCollector: Exception in ReadBroadcastProcessLoop");
                }
            }
        }
    }
}
