using System;
using System.Data.SqlClient;
using System.Data;

namespace MC_Api.Services {
    public class SQL : Config {
        private SqlConnection SqlConn_;
        private SqlCommand SqlCmd_;
        private DataTable Datatable_;
        private readonly string StrConn_ = "Server=[SVR];Database=[DB];";
        private readonly string StrSqlConn_ = "User Id=[USR];Password=[PWD];";
        private readonly string StrWinConn_ = "Trusted_Connection=True;";
        private readonly int TryMax = 3;
        private int TryCurrent = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public DataTable GetSQL(dynamic _model) {
            try {
                InitConnection();
                Datatable_ = new DataTable();
                if (SQLOpen()) {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_model.Cmd, SqlConn_)) {
                        if (_model.Param.Count > 0) SetParameters(sqlDataAdapter, _model.Param);
                        
                        sqlDataAdapter.Fill(Datatable_);
                    }
                    SQLClose();
                }
                return Datatable_;
            } finally {
                EndConnection();
            }
        }

        private SqlDataAdapter SetParameters(SqlDataAdapter _sqlDataAdapter, dynamic _model) {
            foreach(var m in _model) {
                _sqlDataAdapter.SelectCommand.Parameters.Add("@" + m.Key, SqlDbType.Int, 4).Value = m.Value;
            }
            return _sqlDataAdapter;
        }

        #region Open or close connection
        private bool SQLOpen() {
            SqlConn_ = new SqlConnection(GetConnectionString());
            SqlConn_.Open();
            if (SqlConn_ != null && SqlConn_.State == ConnectionState.Closed) TryAgain(true, "No connect with server ");
            return true;
        }
        private void SQLClose() {
            SqlConn_.Close();
            if (SqlConn_ != null && SqlConn_.State == ConnectionState.Open) TryAgain(false, "No disconnect with server ");
        }
        private void TryAgain(bool _openConnection, string _msgError) {
            TryCurrent++;
            if (TryCurrent == TryMax) throw new Exception(_msgError + GetSvr_MC() + ", Check and try again");
            if (_openConnection) SQLOpen();
            else SQLClose();
        }
        #endregion        
        #region Connection String
        private string GetConnectionString(bool _win = false) {
            if (_win) return StrConn_.Replace("[SVR]", GetSvr_MC()).Replace("[DB]", GetDb_MC()) + GetConnWithSql(GetUsr_MC(), GetPwd_MC());
            return StrConn_.Replace("[SVR]", GetSvr_MC()).Replace("[DB]", GetDb_MC()) + GetConnWithWin();
        }
        private string GetConnWithSql(string _usr, string _pwd) => StrSqlConn_.Replace("[USR]", _usr).Replace("[PWD]", _pwd);
        private string GetConnWithWin() => StrWinConn_;
        #endregion
        #region Configuration to init or finish connection.
        private void InitConnection() {
            TryCurrent = 0;
            Datatable_ = null;
            if (SqlConn_ != null) SqlConn_.Close();
            SqlConn_ = null;
        }
        private void EndConnection() {
            TryCurrent = 0;
            Datatable_ = null;
            if (SqlCmd_ != null) SqlCmd_.Cancel();
            if (SqlConn_ != null) SqlConn_.Close();            
            SqlCmd_ = null;
            SqlConn_ = null;
        }
        #endregion
    }
}