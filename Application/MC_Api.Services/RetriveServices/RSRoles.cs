using MC_Api.Models;
using System;

namespace MC_Api.Services.RetriveServices {
    public class RSRoles : FN {
        public TrasactionResult GetAllRoles() {
            try {
                return new TrasactionResult() {
                    Data = ""
                };
            } finally {

            }
        }
        public TrasactionResult GetRoleByID(Guid _id) {
            return new TrasactionResult();
        }
    }
}