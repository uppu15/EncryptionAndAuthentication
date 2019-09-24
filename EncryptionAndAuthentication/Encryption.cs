using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace EncryptionAndAuthentication
{
    class Encryption
    {
        public static string CreateKey(string password)
        {

            using (SHA512 shaHash = SHA512.Create())
            { 
                string encrypted = GetEncryption(shaHash, password);
                return encrypted;
            }
        }

        static string GetEncryption(SHA512 shaHash, string password)
        {
            byte[] data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder passwordEncryption = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                passwordEncryption.Append(data[i].ToString("x2"));
            }

            return passwordEncryption.ToString();
        }
    }
}
