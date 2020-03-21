using MC_Api.Models;
using MC_Api.Services.RetriveServices;
using System;
using System.Web.Http;

namespace MC_Api.ManageCash {
    public class RolesController : BaseApiController {
        private RSRoles RSRoles_;
        

        [ActionName("GetAllRoles"), HttpGet]
        public TrasactionResult GetAll() {
            try {
                RSRoles_ = new RSRoles();
                return PassResult(RSRoles_.GetAllRoles());
            } catch (Exception _ex) {
                Msg = _ex.Message;
                if (!_ex.Message.Contains("@MC_Objects")) Msg += " @MC_Objects into class: RSRoles";
                return ErrorResult("GetAll", "Roles", Msg);
            } finally {
                RSRoles_ = null;
                Msg = null;
            }
        }
        [ActionName("GetRoleByID"), HttpGet]
        public TrasactionResult GetID(ModelById _model) {
            try {
                RSRoles_ = new RSRoles();
                return PassResult(RSRoles_.GetRoleByID(_model.Id));
            } catch (Exception _ex) {
                Msg = _ex.Message;
                if (!_ex.Message.Contains("@MC_Objects")) Msg += " @MC_Objects into class: RSRoles";
                return ErrorResult("GetID", "Roles", Msg);
            } finally {
                RSRoles_ = null;
                Msg = null;
            }
        }
    }
}