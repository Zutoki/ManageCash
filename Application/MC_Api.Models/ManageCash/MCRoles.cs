using System;

namespace MC_Api.Models {
    public class MCRoles {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public bool Available { get; set; } = true;
    }
}