
    
using static mrgada.S7Collector;

public static partial class mrgada
{
    public partial class _MRP6
    {
        public class c_dbPLI: mrgada.S7Db
        {
            #region public vars
            
                public List<S7Var<Int16>> PLI_EX = new(151);
                public List<S7Var<Int16>> PLI_ST = new(151);
                public List<S7Var<Int16>> PLI_SI = new(151);
                public List<S7Var<Int16>> PLI_OP = new(151);
                public List<S7Var<Int16>> PLI_WR = new(151);
                public List<S7Var<Int16>> PLI_OC = new(151);
                public List<S7Var<Int16>> PLI_CD = new(151);
                public List<S7Var<Int16>> PLI_IS = new(151);
                public List<S7Var<Int16>> PLI_UN = new(151);
                public List<S7Var<Int16>> PLI_F = new(151);
                public List<S7Var<Int16>> PLI_RQ = new(151);
                public List<S7Var<Int16>> PLI_SB = new(151);
                public List<S7Var<Int16>> PLI_BRQ = new(151);
                public List<S7Var<Int16>> PLI_HI = new(151);
                public List<S7Var<Int16>> PLI_MS = new(151);
                public List<S7Var<Int16>> PLI_MD = new(151);
                public List<S7Var<bool>> PLI_RC = new(151);
                public List<S7Var<bool>> PLI_TC = new(151);
                public List<S7Var<bool>> PLI_AC = new(151);
                public List<S7Var<bool>> PLI_HC = new(151);
                public List<S7Var<bool>> PLI_SC = new(151);
                public List<S7Var<bool>> PLI_EC = new(151);
                public List<S7Var<bool>> PLI_R = new(151);
                public List<S7Var<bool>> PLI_T = new(151);
                public List<S7Var<bool>> PLI_A = new(151);
                public List<S7Var<bool>> PLI_H = new(151);
                public List<S7Var<bool>> PLI_S = new(151);
                public List<S7Var<bool>> PLI_E = new(151);
                public List<S7Var<bool>> PLI_I = new(151);
                public List<S7Var<bool>> PLI_C = new(151);
                public List<S7Var<bool>> PLI_AD = new(151);
                public List<S7Var<bool>> PLI_HD = new(151);
                public List<S7Var<bool>> PLI_SD = new(151);
                public List<S7Var<bool>> PLI_FI = new(151);
                public List<S7Var<bool>> PLI_W = new(151);
                public List<S7Var<bool>> PLI_P = new(151);
                public List<S7Var<bool>> PLI_PD = new(151);
                public List<S7Var<bool>> PLI_SS = new(151);
                public List<S7Var<bool>> PLI_NC = new(151);
                public List<S7Var<bool>> PLI_IN = new(151);
                public List<S7Var<bool>> PLI_ER = new(151);
                public List<S7Var<bool>> PLI_OR = new(151);
                public List<S7Var<bool>> PLI_RR = new(151);
                public List<S7Var<bool>> PLI_CR = new(151);
                public List<S7Var<bool>> PLI_RE = new(151);
                public List<S7Var<bool>> PLI_DL = new(151);
                public List<S7Var<bool>> PLI_WC = new(151);
                public List<S7Var<bool>> PLI_II = new(151);
                public List<S7Var<bool>> PLI_HA = new(151);

        #endregion

                private mrgada.S7ClientCollector _s7CollectorClient;
                private S7.Net.Plc _s7Plc;
                public c_dbPLI(int num, int len, mrgada.S7ClientCollector s7CollectorClient, S7.Net.Plc s7Plc) : base(num, len)
                {
                    _s7CollectorClient = s7CollectorClient;
                    _s7Plc = s7Plc;

                    #region init vars
                    int i = 0;
    
                    for (i = 0; i <= 150; i++) {
                        PLI_EX.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_ST.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_SI.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_OP.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_WR.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_OC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_CD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_IS.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_UN.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_F.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_RQ.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_SB.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_BRQ.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_HI.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_MS.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_MD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_RC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_TC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_AC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_HC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_SC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_EC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_R.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_T.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_A.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_H.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_S.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_E.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_I.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_C.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_AD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_HD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_SD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_FI.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_W.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_P.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_PD.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_SS.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_NC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_IN.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_ER.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_OR.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_RR.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_CR.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_RE.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_DL.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_WC.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_II.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
                    for (i = 0; i <= 150; i++) {
                        PLI_HA.Insert(i, new(this, s7CollectorClient, s7Plc));
                    }
        
            #endregion
                    AlignAndIncrement();
                }
                
                public void AlignAndIncrement()
                {
                    int bitOffset = 0;
                    int i = 0;
            
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_EX[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_ST[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SI[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OP[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_WR[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_CD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_IS[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_UN[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_F[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RQ[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SB[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_BRQ[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HI[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_MS[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(Int16), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_MD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_TC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_AC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_EC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_R[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_T[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_A[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_H[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_S[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_E[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_I[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_C[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_AD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_HD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_FI[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_W[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_P[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_PD[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_SS[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_NC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_IN[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_ER[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_OR[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RR[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_CR[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_RE[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_DL[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_WC[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
                    for (i = 1; i <= 150; i++) {
                        bitOffset = PLI_II[i].AlignAndIncrement(bitOffset);
                    }
        
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof(bool), 2)) * 8; // align bit offset because it is start of array
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
    