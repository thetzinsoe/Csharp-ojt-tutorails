using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Services.PassEncrypt
{
    public class EncryptionHelper
    {
        private const string EncryptionKey = "whoareyou"; // Change this key to your own secure key

        public string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(EncryptionKey, aes.IV);
                aes.Key = deriveBytes.GetBytes(32);
                aes.Mode = CipherMode.CBC;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(BitConverter.GetBytes(aes.IV.Length), 0, sizeof(int));
                    memoryStream.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    byte[] ivLengthBytes = new byte[sizeof(int)];
                    Array.Copy(cipherBytes, ivLengthBytes, ivLengthBytes.Length);
                    int ivLength = BitConverter.ToInt32(ivLengthBytes, 0);
                    byte[] iv = new byte[ivLength];
                    Array.Copy(cipherBytes, sizeof(int), iv, 0, iv.Length);

                    aes.IV = iv;

                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(EncryptionKey, aes.IV);
                    aes.Key = deriveBytes.GetBytes(32);
                    using (MemoryStream memoryStream = new MemoryStream(cipherBytes, sizeof(int) + iv.Length, cipherBytes.Length - (sizeof(int) + iv.Length)))
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Input is not a valid base64 string.");
                throw;
            }
        }
    }
}

