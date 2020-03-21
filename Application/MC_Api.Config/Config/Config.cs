namespace MC_Api {
    public class Config : FN {
        private static readonly string MC_Svr = "hGeoSBs79Cc57GUH5mFJtj4ZUgu2hj70";
        private static readonly string MC_Db = "KaSAvnoYT/REB9FfT5uL+Q==";
        private static readonly string MC_Usr = "+8D/e57jBSKC3IHrcy0Vsw==";
        private static readonly string MC_Pwd = "E3yBMEFI4sx6exWvILUMYA==";
        private static readonly string MC_Key = "*@P4sSw0rd@*";

        public static string GetSvr_MC() => DecodeMD5(MC_Svr, MC_Key);
        public static string GetDb_MC() => DecodeMD5(MC_Db, MC_Key);
        public static string GetUsr_MC() => DecodeMD5(MC_Usr, MC_Key);
        public static string GetPwd_MC() => DecodeMD5(MC_Pwd, MC_Key);
    }
}