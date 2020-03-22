using System;

namespace MC_Api.Models {
    /// <summary>
    /// This class is used for return a standard response.
    /// </summary>
    public class TrasactionResult {
        public short Code { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public System.Collections.Generic.ICollection<string> MessageDetails { get; set; }
        public bool Pass { get; set; }
        public bool Fail { get; set; }
    }
}