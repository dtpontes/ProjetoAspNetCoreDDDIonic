using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace YouLearn.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMD5(this string text)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(text));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
