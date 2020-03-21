using MC_Api.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace MC_Api.ManageCash {
    public class BaseApiController : ApiController {
        private short Code;
        private ICollection<string> MessageDetails;
        public string Msg;

        #region ErrorResult
        /// <summary>
        /// This function is used for create a Transation result standard
        /// </summary>
        /// <param name="_aAction"></param>
        /// <param name="_aController"></param>
        /// <param name="_error"></param>
        /// <returns></returns>
        protected TrasactionResult ErrorResult(string _aAction, string _aController, string _error) {
            try {
                DictionaryofErrors(_error);
                return new TrasactionResult() {
                    Code = Code,
                    Data = new List<string>(),
                    Message = "Error in method " + _aAction + " into " + _aController + ", for more details you can see field 'MessageDetails'",
                    MessageDetails = MessageDetails ?? new List<string>(),
                    Pass = false,
                    Fail = true
                };
            } finally {
                Code = short.MinValue;
                MessageDetails = null;
            }
        }
        #endregion
        #region PassResult
        protected TrasactionResult PassResult(TrasactionResult _tr) {
            try {
                _tr.Code = 200;
                _tr.Message = "";
                _tr.MessageDetails = new List<string>();
                _tr.Pass = true;
                _tr.Fail = false;
                return _tr;
            } finally {
                Code = short.MinValue;
                MessageDetails = null;
            }
        }
        #endregion
        #region SetValueErrorResult
        protected void SetValueErrorResult(IDictionary _iDictionary) {
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
        #endregion
        #region DictionaryofErrors
        private bool DictionaryofErrors(string _error) {
            MessageDetails = new List<string>();
            switch (_error.Split('@')[0]) {
                case "Object reference not set to an instance of an object. ":
                    Code = 409;
                    MessageDetails.Add(_error);
                    return true;
                default: break;
            }
            MessageDetails = null;
            return false;
        }
        #endregion
    }
}