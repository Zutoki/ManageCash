namespace MC_Api.Services {
    public class ServicesBase : Config {
        protected SQL Sql_;
        protected BaseDataSQL BaseDataSql_;
        protected DataTableToModel DataTableToModel_;
        protected string Msg_;

        protected void InitServices() {
            Sql_ = new SQL(GetSvr_MC(), GetDb_MC(), GetUsr_MC(), GetPwd_MC(), false);
            DataTableToModel_ = new DataTableToModel();
        }
        protected BaseParamSQL GetBaseParamSQL(string _key, dynamic _value, BaseParamSQL.AllType _type, int _lenType=0) {
            return new BaseParamSQL() {
                Key = _key,
                Value = _value,
                Type = _type,
                LenType = _lenType
            };
        }
    }
}
