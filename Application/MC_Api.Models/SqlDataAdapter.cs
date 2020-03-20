using System.Collections.Generic;

namespace MC_Api.Models {
    public class MSqlDataAdapter {
        public string Cmd { get; set; }
        public List<MSqlDataAdapterParam> Param { get; set; }

    }
    public class MSqlDataAdapterParam {
        public string Key { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}