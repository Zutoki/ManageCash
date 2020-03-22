using MC_Api.Models;
using MC_Api.Services.RetriveServices;
using MC_Api.Services.WriteServices;
using System;
using System.Web.Http;

namespace MC_Api.ManageCash {
    /// <summary>
    /// This Api is used for all module of Roles into ManageCash
    /// </summary>
    public class RolesController : BaseApiController {
        private RSRoles RSRoles_;
        private WSRoles WSRoles_;
        #region GetAll
        /// <summary>
        /// This function is used for get all Roles into ManageCash.
        /// </summary>
        /// <returns></returns>
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
        #endregion
        #region GetID
        /// <summary>
        /// This function is used for get 1 role with send a Id into Json Body.
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        [ActionName("GetRoleByID"), HttpGet]
        public TrasactionResult GetID(ModelsById _model) {
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
        #endregion
        /// <summary>
        /// This funcion is used for Add or Update Roles with model into json body.
        /// <para>If is Add then send model without ID</para>
        /// <para>If is Updated then send model with ID</para>
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        [ActionName("AddOrUpdateRole"), HttpPost]
        public TrasactionResult AddOrUpdate(MCRoles _model) {
            try {
                WSRoles_ = new WSRoles();
                if (_model.Id == Guid.Parse("00000000-0000-0000-0000-000000000000")) return PassResult(WSRoles_.AddRole(_model));
                return PassResult(WSRoles_.UpdRole(_model));
            } catch (Exception _ex) {
                Msg = _ex.Message;
                if (!_ex.Message.Contains("@MC_Objects")) Msg += " @MC_Objects into class: WSRoles_";
                if (_model.Id == Guid.Parse("00000000-0000-0000-0000-000000000000")) return ErrorResult("AddOrUpdate->Add", "Roles", Msg);
                return ErrorResult("AddOrUpdate->Update", "Roles", Msg);
            } finally {
                WSRoles_ = null;
                Msg = null;
            }
        }
    }
}