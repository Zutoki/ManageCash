using System;
using System.Security.Cryptography;
using System.Text;

namespace MC_Api {
    public class FN {
        #region Encode & Decode
        private static byte[] CipherBytes, Bytes;
        public static string EncodeMD5(string _code, string _key) {
            try {
                using (var md5 = new MD5CryptoServiceProvider()) {
                    using (var tdes = new TripleDESCryptoServiceProvider()) {
                        tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(_key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateEncryptor()) {
                            CipherBytes = Encoding.UTF8.GetBytes(_code);
                            Bytes = transform.TransformFinalBlock(CipherBytes, 0, CipherBytes.Length);
                            return Convert.ToBase64String(Bytes, 0, Bytes.Length);
                        }
                    }
                }
            } finally {
                CipherBytes = null;
                Bytes = null;
            }
        }

        public static string DecodeMD5(string _code, string _key) {
            try {
                using (var md5 = new MD5CryptoServiceProvider()) {
                    using (var tdes = new TripleDESCryptoServiceProvider()) {
                        tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(_key));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateDecryptor()) {
                            CipherBytes = Convert.FromBase64String(_code);
                            Bytes = transform.TransformFinalBlock(CipherBytes, 0, CipherBytes.Length);
                            return Encoding.UTF8.GetString(Bytes);
                        }
                    }
                }
            } finally {
                CipherBytes = null;
                Bytes = null;
            }
        }
        #endregion
    }
}