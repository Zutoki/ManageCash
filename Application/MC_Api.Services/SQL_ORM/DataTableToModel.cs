using MC_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace MC_Api.Services {
    public class DataTableToModel {
        #region Models and List of Models.
        private List<MCRoles> ListMCRoles_;
        public enum Table {
            MCRoles,
            ListMCRoles,
            MCUsers,
            ListMCUsers
        }
        #endregion
        #region GetModel
        public dynamic GetModel(int _table, dynamic _model){
            switch (_table) {
                case 0: return GetModel_MCRoles(_model);
                case 1: return GetListModel_MCRoles(_model);
                default: break;
            }
            throw new Exception("Not exist this model into enum 'Table'");
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
    }
}
