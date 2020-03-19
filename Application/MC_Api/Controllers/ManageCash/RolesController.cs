using MC_Api.Models;
using System;
using System.Web.Http;

namespace MC_Api.ManageCash {
    public class RolesController : BaseApiController {
        
        [ActionName("GetAll")]
        public TrasactionResult GetAllRoles() {
            try {
                /*if ("" != null) WarningResult();
                return PassResult();*/
                return new TrasactionResult();
            } catch (Exception _ex) {
                SetValueErrorResult(_ex.Data);
                return ErrorResult("GetAll", "Roles");
            } finally {

            }
             
        }
    }
}