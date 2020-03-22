using MC_Api.Models;
using System;
using System.Collections.Generic;

namespace MC_Api.Services.WriteServices {
    public class WSRoles : ServicesBase {
        #region AddRole
        public TrasactionResult AddRole(MCRoles _role) {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "AddRole",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>(){
                        GetBaseParamSQL("Name", _role.Name, BaseParamSQL.AllType.VarChar)
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel(DataTableToModel.Table.ModelsById, Sql_.GetSQL(BaseDataSql_)) };
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
        #region UpdRole
        public TrasactionResult UpdRole(MCRoles _role) {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "UpdRole",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>(){
                        GetBaseParamSQL("Id", _role.Id, BaseParamSQL.AllType.Guid),
                        GetBaseParamSQL("Name", _role.Name, BaseParamSQL.AllType.VarChar)
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel(DataTableToModel.Table.ModelsById, Sql_.GetSQL(BaseDataSql_)) };
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
    }
}