using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Lab04_Nhom.CryptoExtension;
using System.Xml;

namespace Lab04_Nhom.CryptoExtension
{
    public static class KeyRepository
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //private static string privatePath = Path.Combine(path, "PrivateKey/" + "{0}" + ".xml");
        //private static string  publicPath = Path.Combine(path, "PublicKey/" + "{0}" + ".xml");

        public static void StorePublicKey(string containerName, string key)
        {
            string publicPath = Path.Combine(path, "PublicKey/" + containerName + ".xml");
            File.WriteAllText(publicPath, key);
        }

        public static void StorePrivateKey(string containerName, string key, string password)
        {
            string privatePath = Path.Combine(path, "PrivateKey/" + containerName + ".xml");

            File.WriteAllText(privatePath, key.GetAES256EncryptString(password));
        }
        public static string GetPublicKey(string containerName)
        {
            string publicPath = Path.Combine(path, "PublicKey/" + containerName + ".xml");
            return File.ReadAllText(publicPath);
        }
        public static string GetPrivateKey(string containerName, string password)
        {
            string privatePath = Path.Combine(path, "PrivateKey/" + containerName + ".xml");
            if (!File.Exists(privatePath))
                return null;

            var privateKeyXml = File.ReadAllText(privatePath).GetAES256DecryptString(password);

            if (!String.IsNullOrWhiteSpace(privateKeyXml) && privateKeyXml.IsValidXml())
                return privateKeyXml;
            else
                return null;
        }
        public static bool isExistsPublicKey(string containerName)
        {
            string publicPath = Path.Combine(path, "PublicKey/" + containerName + ".xml");
            return File.Exists(publicPath);
        }
        
        public static void DeletePublicKey(string containerName)
        {
            string publicPath = Path.Combine(path, "PublicKey/" + containerName + ".xml");
            if (File.Exists(publicPath))
            {
                File.Delete(publicPath);
            }
        }
        public static void DeletePrivateKey(string containerName)
        {
            string privatePath = Path.Combine(path, "PrivateKey/" + containerName + ".xml");
            if (File.Exists(privatePath))
            {
                File.Delete(privatePath);
            }
        }

        public static void StoreKeyPairs(string containerName, RSAKey key, string password)
        {
            StorePublicKey(containerName, key.publicKey);
            StorePrivateKey(containerName, key.privateKey, password);
        }

        public static void DeleteKeyPairs(string containerName)
        {
            DeletePublicKey(containerName);
            DeletePrivateKey(containerName);
        }
    }

}
