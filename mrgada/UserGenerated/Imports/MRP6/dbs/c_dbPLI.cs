
    
using static mrgada.S7Collector;

public static partial class mrgada
{
    public partial class _MRP6
    {
        public class c_dbPLI: mrgada.S7Db
        {
            #region public vars
            
                public List<S7Var<int>> PLI_EX = [];
                public List<S7Var<int>> PLI_ST = [];
                public List<S7Var<int>> PLI_SI = [];
                public List<S7Var<int>> PLI_OP = [];
                public List<S7Var<ushort>> PLI_WR = [];
                public List<S7Var<int>> PLI_OC = [];
                public List<S7Var<int>> PLI_CD = [];
                public List<S7Var<int>> PLI_IS = [];
                public List<S7Var<int>> PLI_UN = [];
                public List<S7Var<int>> PLI_F = [];
                public List<S7Var<int>> PLI_RQ = [];
                public List<S7Var<int>> PLI_SB = [];
                public List<S7Var<int>> PLI_BRQ = [];
                public List<S7Var<int>> PLI_HI = [];
                public List<S7Var<int>> PLI_MS = [];
                public List<S7Var<int>> PLI_MD = [];
                public List<S7Var<bool>> PLI_RC = [];
                public List<S7Var<bool>> PLI_TC = [];
                public List<S7Var<bool>> PLI_AC = [];
                public List<S7Var<bool>> PLI_HC = [];
                public List<S7Var<bool>> PLI_SC = [];
                public List<S7Var<bool>> PLI_EC = [];
                public List<S7Var<bool>> PLI_R = [];
                public List<S7Var<bool>> PLI_T = [];
                public List<S7Var<bool>> PLI_A = [];
                public List<S7Var<bool>> PLI_H = [];
                public List<S7Var<bool>> PLI_S = [];
                public List<S7Var<bool>> PLI_E = [];
                public List<S7Var<bool>> PLI_I = [];
                public List<S7Var<bool>> PLI_C = [];
                public List<S7Var<bool>> PLI_AD = [];
                public List<S7Var<bool>> PLI_HD = [];
                public List<S7Var<bool>> PLI_SD = [];
                public List<S7Var<bool>> PLI_FI = [];
                public List<S7Var<bool>> PLI_W = [];
                public List<S7Var<bool>> PLI_P = [];
                public List<S7Var<bool>> PLI_PD = [];
                public List<S7Var<bool>> PLI_SS = [];
                public List<S7Var<bool>> PLI_NC = [];
                public List<S7Var<bool>> PLI_IN = [];
                public List<S7Var<bool>> PLI_ER = [];
                public List<S7Var<bool>> PLI_OR = [];
                public List<S7Var<bool>> PLI_RR = [];
                public List<S7Var<bool>> PLI_CR = [];
                public List<S7Var<bool>> PLI_RE = [];
                public List<S7Var<bool>> PLI_DL = [];
                public List<S7Var<bool>> PLI_WC = [];
                public List<S7Var<bool>> PLI_II = [];
                public List<S7Var<bool>> PLI_HA = [];

        #endregion

                private mrgada.S7ClientCollector _s7CollectorClient;
                private S7.Net.Plc _s7Plc;
                public c_dbPLI(int num, int len, mrgada.S7ClientCollector s7CollectorClient, S7.Net.Plc s7Plc) : base(num, len)
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
                int i = 0;
                
                    for (i = 1; i <= 150; i++) {
                        PLI_EX[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ST[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SI[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OP[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WR[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IS[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_UN[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_F[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RQ[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SB[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_BRQ[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HI[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MS[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_MD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_TC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_EC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_R[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_T[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_A[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_H[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_S[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_E[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_I[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_C[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_AD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_FI[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_W[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_P[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_PD[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_SS[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_NC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_IN[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_ER[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_OR[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RR[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_CR[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_RE[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_DL[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_WC[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_II[i].ParseCVs();
                    }
        
                    for (i = 1; i <= 150; i++) {
                        PLI_HA[i].ParseCVs();
                    }
        
                }
        }
    }
}
    