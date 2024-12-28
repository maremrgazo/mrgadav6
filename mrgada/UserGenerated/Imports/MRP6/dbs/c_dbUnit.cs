
    
using static mrgada.S7Collector;

public static partial class mrgada
{
    public partial class MRP6
    {
        public class c_dbUnit: mrgada.S7Db
        {
            #region public vars
            
                public List<S7Var<udtUnit>> Unit = [];

        #endregion

                private mrgada.S7ClientCollector _s7CollectorClient;
                private S7.Net.Plc _s7Plc;
                public c_dbAnalogSensorsSCADA(int num, int len, mrgada.S7ClientCollector s7CollectorClient, S7.Net.Plc s7Plc) : base(num, len)
                {
                    _s7CollectorClient = s7CollectorClient;
                    _s7Plc = s7Plc;

                    #region init vars
                    int i = 0;
    
                    for (i = 1; i <= 10; i++) {
                        Unit[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
            #endregion
                    AlignAndIncrement();
                }
                
                public void AlignAndIncrement()
                {
                    int bitOffset = 0;
                    int i = 0;
            
                    for (i = 1; i <= 10; i++) {
                        bitOffset = Unit[i].AlignAndIncrement(bitOffset);
                    }
        
            }

            public override void ParseCVs()
            {
                
                    for (i = 1; i <= 10; i++) {
                        Unit[i].ParseCVs(Bytes);
                    }
        
                }
        }
    }
}
    