using MC_Api.Models;
using System;
using System.Collections.Generic;

namespace MC_Api.Services.RetriveServices {
    public class RSRoles : Config {
        private SQL Sql_;
        private BaseDataSQL BaseDataSql_;
        private DataTableToModel DataTableToModel_;
        private string Msg_;

        #region GetAllRoles
        public TrasactionResult GetAllRoles() {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "GetAllAdminModels",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>(){
                        new BaseParamSQL() {
                            Key = "Type",
                            Value = "0",
                            Type = BaseParamSQL.AllType.Int
                        }
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel((int)DataTableToModel.Table.ListMCRoles, Sql_.GetSQL(BaseDataSql_)) };
            } catch(Exception _ex) {
                Msg_ = _ex.Message;
                if (!_ex.Message.Contains("@MC_Objects")) Msg_ = _ex.Message + " @MC_Objects into class: SQL, BaseDataSQL, DataTableToModel, TrasactionResult";
                throw new Exception(Msg_);
            } finally {
                Sql_ = null;
                BaseDataSql_ = null;
                DataTableToModel_ = null;
                Msg_ = null;
            }
        }
        #endregion
        public TrasactionResult GetRoleByID(Guid _id) {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "GetIdAdminModels",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>() {
                        new BaseParamSQL() {
                            Key = "Type",
                            Value = "0",
                            Type = BaseParamSQL.AllType.Int
                        }, 
                        new BaseParamSQL() {
                            Key = "Id",
                            Value = _id,
                            Type = BaseParamSQL.AllType.Guid
                        }
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel((int)DataTableToModel.Table.MCRoles, Sql_.GetSQL(BaseDataSql_)) };
            } catch(Exception _ex) {
                Msg_ = _ex.Message;
                if (!_ex.Message.Contains("@MC_Objects")) Msg_ = _ex.Message + " @MC_Objects into class: SQL, BaseDataSQL, DataTableToModel, TrasactionResult";
                throw new Exception(Msg_);
            } finally {
                Sql_ = null;
                BaseDataSql_ = null;
                DataTableToModel_ = null;
                Msg_ = null;
            }
        }
        private void InitServices() {
            Sql_ = new SQL(GetSvr_MC(), GetDb_MC(), GetUsr_MC(), GetPwd_MC(), false);
            DataTableToModel_ = new DataTableToModel();
        }
    }
}