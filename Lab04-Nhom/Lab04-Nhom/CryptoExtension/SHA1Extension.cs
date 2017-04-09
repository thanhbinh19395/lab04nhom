using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Nhom.CryptoExtension
{
    public static class SHA1Extension
    {
        public static string GetSHA1Hash(this string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
