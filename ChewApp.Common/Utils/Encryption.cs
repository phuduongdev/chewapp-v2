using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Common.Utils {
    public class Encryption {
        public static string EncodeSHA1(string plainPassword) {
            var sha1 = new SHA1CryptoServiceProvider();

            var convertToBytes = Encoding.UTF8.GetBytes(plainPassword);

            var hashBytes = sha1.ComputeHash(convertToBytes);

            var encodePassword = new StringBuilder();

            foreach(byte b in hashBytes) {
                encodePassword.Append(b.ToString("x1").ToLower());
            }

            return encodePassword.ToString();
        }
    }
}
