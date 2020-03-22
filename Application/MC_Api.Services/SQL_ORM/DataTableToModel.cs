using MC_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace MC_Api.Services {
    public class DataTableToModel {
        #region Models and List of Models.
        private List<MCRoles> ListMCRoles_;
        private List<MCUsers> ListMCUsers_;
        public enum Table {
            ModelsById,
            MCRoles,
            ListMCRoles,
            MCUsers,
            ListMCUsers
        }
        #endregion
        #region GetModel
        public dynamic GetModel(Table _table, dynamic _model){
            switch (_table.ToString()) {
                case "ModelsById": return GetModel_ModelsById(_model[0]);
                case "MCRoles": return GetModel_MCRoles(_model[0]);
                case "ListMCRoles": return GetListModel_MCRoles(_model);
                case "MCUsers": return GetModel_MCUsers(_model[0]);
                case "ListMCUsers": return GetListModel_MCUsers(_model[0]);
                default: break;
            }
            throw new Exception("Not exist this model into enum 'Table'");
        }
        #endregion
        #region Create models or list to ModelById
        private ModelsById GetModel_ModelsById(DataRow _dataRow) {
            if (_dataRow == null) return new ModelsById();
            return new ModelsById() { Id = _dataRow.Field<Guid>("Id") };
        }
        #endregion
        #region Create models or list to MCRoles
        private List<MCRoles> GetListModel_MCRoles(List<DataRow> _list) {
            try {
                ListMCRoles_ = new List<MCRoles>();
                foreach (var _l in _list) {
                    ListMCRoles_.Add(GetModel_MCRoles(_l));
                }
                return ListMCRoles_;
            } finally {
                ListMCRoles_ = null;
            }
        }
        private MCRoles GetModel_MCRoles(DataRow _dataRow) {
            if (_dataRow == null) return new MCRoles();
            return new MCRoles() {
                Id = _dataRow.Field<Guid>("Id"),
                Name = _dataRow.Field<string>("Name"),
                LastUpdated = _dataRow.Field<DateTime>("LastUpdated"),
                Available = _dataRow.Field<bool>("Available")
            };
        }
        #endregion
        #region Create models or list to MCUsers
        private List<MCUsers> GetListModel_MCUsers(List<DataRow> _list) {
            try {
                ListMCUsers_ = new List<MCUsers>();
                foreach (var _l in _list) {
                    ListMCUsers_.Add(GetModel_MCUsers(_l));
                }
                return ListMCUsers_;
            } finally {
                ListMCUsers_ = null;
            }
        }
        private MCUsers GetModel_MCUsers(DataRow _dataRow) {
            if (_dataRow == null) return new MCUsers();
            return new MCUsers() {
                Id = _dataRow.Field<Guid>("Id"),
                MCRolesId = _dataRow.Field<Guid>("MCRolesId"),
                UserName = _dataRow.Field<string>("UserName"),
                Email = _dataRow.Field<string>("Email"),
                FirstName = _dataRow.Field<string>("FirstName"),
                LastName = _dataRow.Field<string>("LastName"),
                LastUpdated = _dataRow.Field<DateTime>("LastUpdated"),
                Available = _dataRow.Field<bool>("Available")
            };
        }
        #endregion
    }
}
