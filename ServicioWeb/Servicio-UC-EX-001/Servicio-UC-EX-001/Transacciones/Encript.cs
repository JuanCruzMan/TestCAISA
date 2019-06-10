using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Servicio_UC_EX_001.Transacciones
{
    class StringPassword
    {
        public string Encrypt(string PlainText)
        {
            string Password = "J@r3fN3tCrzM@nJCM";
            string SaltValue = "MD5";
            string HashAlgorithm = "MD5";
            int PasswordIterations = 1;
            string InitialVector = "D3p@rtOfSyst3msnJCM";
            int KeySize = 128;
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(PlainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(Password, saltValueBytes, HashAlgorithm, PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);

                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);

                return cipherText;
            }
            catch
            {
                return null;
            }
        }

        public string Decrypt(string PlainText)
        {
            string Password = "J@r3fN3tCrzM@nJCM";
            string SaltValue = "MD5";
            string HashAlgorithm = "MD5";
            int PasswordIterations = 1;
            string InitialVector = "D3p@rtOfSyst3msnJCM";
            int KeySize = 128;
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] saltValueBytes = System.Text.Encoding.ASCII.GetBytes(SaltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(PlainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(Password, saltValueBytes, HashAlgorithm, PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitialVectorBytes);

                System.IO.MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
            catch
            {
                return null;
            }
        }
    }
}