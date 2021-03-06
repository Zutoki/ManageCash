﻿using MC_Api.Models;
using System;
using System.Collections.Generic;

namespace MC_Api.Services.RetriveServices {
    public class RSRoles : ServicesBase {
        #region GetAllRoles
        public TrasactionResult GetAllRoles() {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "GetAllAdminModels",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>(){
                        GetBaseParamSQL("Type", 0, BaseParamSQL.AllType.Int)
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel(DataTableToModel.Table.ListMCRoles, Sql_.GetSQL(BaseDataSql_)) };
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
        #region GetRoleByID
        public TrasactionResult GetRoleByID(Guid _id) {
            try {
                InitServices();
                BaseDataSql_ = new BaseDataSQL() {
                    Cmd = "GetIdAdminModels",
                    CmdType = BaseDataSQL.AllCmdType.SP,
                    Param = new List<BaseParamSQL>() {
                        GetBaseParamSQL("Type", 0, BaseParamSQL.AllType.Int),
                        GetBaseParamSQL("Id", _id, BaseParamSQL.AllType.Guid)
                    }
                };
                return new TrasactionResult() { Data = DataTableToModel_.GetModel(DataTableToModel.Table.MCRoles, Sql_.GetSQL(BaseDataSql_)) };
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