using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Common.Security
{
    public class Token
    {

        public string GenerateToken(int size, string customChars = "")
        {
            char[] chars = string.IsNullOrEmpty(customChars)
                           ? "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray()
                           : customChars.ToCharArray();
            customChars.ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

    }
}
