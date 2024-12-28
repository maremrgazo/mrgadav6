
    
using static mrgada.S7Collector;

public static partial class mrgada
{
    public partial class MRP6
    {
        public class c_dbPLI: mrgada.S7Db
        {
            #region public vars
            
                public List<S7Var<Int>> PLI_EX = [];
                public List<S7Var<Int>> PLI_ST = [];
                public List<S7Var<Int>> PLI_SI = [];
                public List<S7Var<Int>> PLI_OP = [];
                public List<S7Var<Word>> PLI_WR = [];
                public List<S7Var<Int>> PLI_OC = [];
                public List<S7Var<Int>> PLI_CD = [];
                public List<S7Var<Int>> PLI_IS = [];
                public List<S7Var<Int>> PLI_UN = [];
                public List<S7Var<Int>> PLI_F = [];
                public List<S7Var<Int>> PLI_RQ = [];
                public List<S7Var<Int>> PLI_SB = [];
                public List<S7Var<Int>> PLI_BRQ = [];
                public List<S7Var<Int>> PLI_HI = [];
                public List<S7Var<Int>> PLI_MS = [];
                public List<S7Var<Int>> PLI_MD = [];
                public List<S7Var<Bool>> PLI_RC = [];
                public List<S7Var<Bool>> PLI_TC = [];
                public List<S7Var<Bool>> PLI_AC = [];
                public List<S7Var<Bool>> PLI_HC = [];
                public List<S7Var<Bool>> PLI_SC = [];
                public List<S7Var<Bool>> PLI_EC = [];
                public List<S7Var<Bool>> PLI_R = [];
                public List<S7Var<Bool>> PLI_T = [];
                public List<S7Var<Bool>> PLI_A = [];
                public List<S7Var<Bool>> PLI_H = [];
                public List<S7Var<Bool>> PLI_S = [];
                public List<S7Var<Bool>> PLI_E = [];
                public List<S7Var<Bool>> PLI_I = [];
                public List<S7Var<Bool>> PLI_C = [];
                public List<S7Var<Bool>> PLI_AD = [];
                public List<S7Var<Bool>> PLI_HD = [];
                public List<S7Var<Bool>> PLI_SD = [];
                public List<S7Var<Bool>> PLI_FI = [];
                public List<S7Var<Bool>> PLI_W = [];
                public List<S7Var<Bool>> PLI_P = [];
                public List<S7Var<Bool>> PLI_PD = [];
                public List<S7Var<Bool>> PLI_SS = [];
                public List<S7Var<Bool>> PLI_NC = [];
                public List<S7Var<Bool>> PLI_IN = [];
                public List<S7Var<Bool>> PLI_ER = [];
                public List<S7Var<Bool>> PLI_OR = [];
                public List<S7Var<Bool>> PLI_RR = [];
                public List<S7Var<Bool>> PLI_CR = [];
                public List<S7Var<Bool>> PLI_RE = [];
                public List<S7Var<Bool>> PLI_DL = [];
                public List<S7Var<Bool>> PLI_WC = [];
                public List<S7Var<Bool>> PLI_II = [];
                public List<S7Var<Bool>> PLI_HA = [];

        #endregion

                private mrgada.S7ClientCollector _s7CollectorClient;
                private S7.Net.Plc _s7Plc;
                public c_dbAnalogSensorsSCADA(int num, int len, mrgada.S7ClientCollector s7CollectorClient, S7.Net.Plc s7Plc) : base(num, len)
                {
                    _s7CollectorClient = s7CollectorClient;
                    _s7Plc = s7Plc;

                    #region init vars
                    int i = 0;
    
                    for (i = 1; i <= 150; i++) {
                        PLI_EX[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ST[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SI[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OP[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WR[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IS[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_UN[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_F[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RQ[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SB[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_BRQ[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HI[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MS[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_TC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_EC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_R[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_T[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_A[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_H[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_S[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_E[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_I[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_C[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_FI[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_W[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_P[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_PD[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SS[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_NC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IN[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ER[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OR[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RR[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CR[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RE[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_DL[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WC[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_II[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HA[i] = new(this, s7CollectorClient, s7Plc);
                    }
        
            #endregion
                    AlignAndIncrement();
                }
                
                public void AlignAndIncrement()
                {
                    int bitOffset = 0;
                    int i = 0;
            
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_EX[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_ST[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SI[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OP[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_WR[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_CD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_IS[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_UN[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_F[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RQ[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SB[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_BRQ[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HI[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_MS[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_MD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_TC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_AC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_EC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_R[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_T[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_A[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_H[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_S[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_E[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_I[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_C[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_AD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_FI[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_W[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_P[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_PD[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SS[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_NC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_IN[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_ER[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OR[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RR[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_CR[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RE[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_DL[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_WC[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_II[i].AlignAndIncrement(bitOffset);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HA[i].AlignAndIncrement(bitOffset);
                    }
        
            }

            public override void ParseCVs()
            {
                
                    for (i = 1; i <= 150; i++) {
                        PLI_EX[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ST[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SI[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OP[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WR[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IS[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_UN[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_F[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RQ[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SB[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_BRQ[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HI[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MS[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_TC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_EC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_R[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_T[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_A[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_H[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_S[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_E[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_I[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_C[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_FI[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_W[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_P[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_PD[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SS[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_NC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IN[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ER[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OR[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RR[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CR[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RE[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_DL[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WC[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_II[i].ParseCVs(Bytes);
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HA[i].ParseCVs(Bytes);
                    }
        
                }
        }
    }
}
    