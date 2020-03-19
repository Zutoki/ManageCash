using System;

namespace MC_Api.Models {
    public class MCUsers {
        
        public Guid Id { get; set; }
        public Guid MCRolesId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public bool Available { get; set; } = true;
    }
}
