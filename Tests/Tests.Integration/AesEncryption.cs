using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Tests.Integration
{
    public static class AesEncryption
    {
        public static byte[] Encrypt(byte[] clearData, byte[] Key)
        {
            var memoryStream = new MemoryStream();

            Rijndael algorithm = Rijndael.Create();
            
            algorithm.Key = Key;
            algorithm.KeySize = 192;

            var criptoStream = new CryptoStream(memoryStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            criptoStream.Write(clearData, 0, clearData.Length);
            criptoStream.Close();

            byte[] encryptedData = memoryStream.ToArray();
            return encryptedData;
        }

        public  static byte[] Decrypt(byte[] cipherData, byte[] Key)
        {
            var memoryStream = new MemoryStream();

            Rijndael algorithm = Rijndael.Create();

            algorithm.Key = Key;
            algorithm.KeySize = 192;

            var criptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Write);

            criptoStream.Write(cipherData, 0, cipherData.Length);

            criptoStream.Close();

            byte[] decryptedData = memoryStream.ToArray();

            return decryptedData;
        }
    }
    
}