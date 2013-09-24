using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebAppSecurityDemo.Models
{
    public class Encryption
    {
        public static string Encrypt(string input)
        {
            var saltBytes = System.Text.Encoding.Unicode.GetBytes(salt);
            var inputBytes = System.Text.Encoding.Unicode.GetBytes(input);
            var db = new Rfc2898DeriveBytes(password, saltBytes);
            var strm = new MemoryStream();
            var algorithm = Rijndael.Create();
            algorithm.Key = db.GetBytes(32);
            algorithm.IV = db.GetBytes(16);
            var cs = new CryptoStream(strm, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputBytes, 0, inputBytes.Length);
            cs.FlushFinalBlock();
            var outputBytes = strm.ToArray();
            return Convert.ToBase64String(outputBytes);

        }

        public static string Decrypt(string input)
        {
            var saltBytes = System.Text.Encoding.Unicode.GetBytes(salt);
            var inputBytes = Convert.FromBase64String(input);
            var db = new Rfc2898DeriveBytes(password, saltBytes);
            var strm = new MemoryStream();
            var algorithm = Rijndael.Create();
            algorithm.Key = db.GetBytes(32);
            algorithm.IV = db.GetBytes(16);
            var cs = new CryptoStream(strm, algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputBytes, 0, inputBytes.Length);
            cs.FlushFinalBlock();
            var outputBytes = strm.ToArray();
            return System.Text.Encoding.Unicode.GetString(outputBytes);
        }


        private const string salt = "this is my salt";
        public const string password = "this is the password then";
    }
}