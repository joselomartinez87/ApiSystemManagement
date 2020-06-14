using System;
using System.Security.Cryptography;
using System.Text;

namespace SystemManagement.Common.Security
{
    public class AES256
    {

        private readonly string AesIV256 = "SP!<OL1MP<S1DXTK";
        private readonly string AesKey256 = "20Y18&&OL1SP(TK<SCMSD&66LQA2)KI<";

        /// <summary>
        /// AES encryption
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);
            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES decryption
        /// </summary>
        public string Decrypt(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);
            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

    }
}
