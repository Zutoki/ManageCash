namespace MC_Api {
    public class Config : FN {
        private static readonly string MC_Svr = "";
        private static readonly string MC_Db = "";
        private static readonly string MC_Usr = "";
        private static readonly string MC_Pwd = "";
        private static readonly string MC_Key = "*@P4sSw0rd@*";

        public string GetSvr_MC() => DecodeMD5(MC_Svr, MC_Key);
        public string GetDb_MC() => DecodeMD5(MC_Db, MC_Key);
        public string GetUsr_MC() => DecodeMD5(MC_Usr, MC_Key);
        public string GetPwd_MC() => DecodeMD5(MC_Pwd, MC_Key);
    }
}