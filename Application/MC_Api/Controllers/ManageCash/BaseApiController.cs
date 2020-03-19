using MC_Api.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace MC_Api.ManageCash {
    public class BaseApiController : ApiController {
        public short Code = 404;
        public ICollection<string> MessageDetails = new List<string>(){"Error intern, Method with error"};

        /// <summary>
        /// This function is used for create a Transation result standard
        /// </summary>
        /// <returns></returns>
        public TrasactionResult ErrorResult(string _aAction, string _aController) =>
            new TrasactionResult() {
                Code = Code,
                Data = new List<string>(),
                Message = "Error in method " + _aAction + " into " + _aController + ", for more details you can see field 'MessageDetails'", 
                MessageDetails = MessageDetails ?? new List<string>(),
                Pass = false,
                Fail = true
            };

        public TrasactionResult PassResult(TrasactionResult _tr) {
            _tr.Code = 200;
            _tr.Message = "";
            _tr.MessageDetails = new List<string>();
            _tr.Pass = true;
            _tr.Fail = false;
            return _tr;
        }
        public void SetValueErrorResult(IDictionary _iDictionary) {
            MessageDetails = new List<string>();
            foreach (DictionaryEntry de in _iDictionary) {
                switch (de.Key.ToString()) {
                    case "Code":
                        Code = short.Parse(de.Value.ToString());
                        break;
                    case "Message":
                        MessageDetails.Add(de.Value.ToString());
                        break;
                }
            }
        }
    }
}