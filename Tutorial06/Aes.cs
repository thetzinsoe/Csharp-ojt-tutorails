using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Mode = CipherMode.CBC;

            using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
            {
                byte[] iv = new byte[sizeof(int)];
                memoryStream.Read(iv, 0, iv.Length);

                aes.IV = iv;

                Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(EncryptionKey, aes.IV);
                aes.Key = deriveBytes.GetBytes(32);

                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cryptoStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

