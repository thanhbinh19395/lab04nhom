using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Nhom.CryptoExtension
{
    public class EncryptorRSA2048Keys
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }

    public static class RSA2048Extension
    {
        public static EncryptorRSA2048Keys GenerateKeys()
        {
            var response = new EncryptorRSA2048Keys();
            var csp = new RSACryptoServiceProvider(2048);

            var privKey = csp.ExportParameters(true);
            var pubKey = csp.ExportParameters(false);

            string pubKeyString;
            {
                var sw = new System.IO.StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, pubKey);
                pubKeyString = sw.ToString();
            }
            {
                //get a stream from the string
                var sr = new System.IO.StringReader(pubKeyString);
                //we need a deserializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //get the object back from the stream
                pubKey = (RSAParameters)xs.Deserialize(sr);
            }


            return response;
        }
       
        public static string GetRSA512EncryptString(this string text, string publicKey)
        {
            var csp = new RSACryptoServiceProvider(2048);
            EncryptorRSA2048Keys.P     
        }
    }
}
