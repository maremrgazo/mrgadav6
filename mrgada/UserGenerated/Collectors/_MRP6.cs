#pragma warning disable CS8981 // suppress naming rule violation
#pragma warning disable CS8618 // suppress non-null value when exiting constructor

using static mrgada._MRP6;

public static partial class mrgada
{
    public static _MRP6 MRP6;
    public partial class _MRP6 : S7Collector
    {
        // editable start

        public c_dbDigialValvesSCADA dbDigialValvesSCADA;
        public c_dbAnalogSensorsSCADA dbAnalogSensorsSCADA;
        public c_dbPLI dbPLI;

        // editable end

        public _MRP6(string name, int port, S7.Net.CpuType cpuType, string plcIp, short plcRack, short plcSlot, int readBroadcastProcessThreadMinIntervalMilliseconds = 100) : base(name, port, cpuType, plcIp, plcRack, plcSlot, readBroadcastProcessThreadMinIntervalMilliseconds)
        {

            // editable start

            dbDigialValvesSCADA = new(52, 792);
            dbAnalogSensorsSCADA = new(51, 2130, _s7ClientCollector, _s7Plc);
            dbPLI = new(101, 5460, _s7ClientCollector, _s7Plc);

            AddS7db(dbDigialValvesSCADA);
            AddS7db(dbAnalogSensorsSCADA);
            AddS7db(dbPLI);

            // editable end
        }
    }
}