using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Analytics.Helpers.Utility
{
    public class Helper
    {
        public static byte[] GetHashKey(string hashKey)
        {
            // Initialise
            UTF8Encoding encoder = new UTF8Encoding();

            // Get the salt
            string salt = "I am a nice little salt";
            byte[] saltBytes = encoder.GetBytes(salt);

            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);

            // Return the key
            return rfc.GetBytes(16);
        }
        public static string Encrypt(byte[] key, string dataToEncrypt)
        {
            // Initialise
            AesManaged encryptor = new AesManaged();

            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;

            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();

                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }
        public static string DecryptQueryString(byte[] key, string encryptedString)
        {
            // Initialise
            AesManaged decryptor = new AesManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptedString);

            // Set the key
            decryptor.Key = key;
            decryptor.IV = key;

            // create a memory stream
            using (MemoryStream decryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    decrypt.Write(encryptedData, 0, encryptedData.Length);
                    decrypt.Flush();
                    decrypt.Close();

                    // Return the unencrypted data
                    byte[] decryptedData = decryptionStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                }
            }
        }
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ToString();
            }
        }

        public static int CurrentUserId
        {
            get
            {

                return Convert.ToInt32(HttpContext.Current.Session["userdata"].ToString().Split('^')[0]);

            }
        }
        public static string CurrentUseremail
        {
            get
            {

                return HttpContext.Current.Session["userdata"].ToString().Split('^')[1];

            }

        }
        public static string CurrentUserName
        {
            get
            {

                return HttpContext.Current.Session["userdata"].ToString().Split('^')[2];

            }

        }
        public static string CurrentUserRole
        {
            get
            {

                return HttpContext.Current.Session["userdata"].ToString().Split('^')[3].ToLower();

            }
        }
       

        //internal static string Decrypt(byte[] key, string encryptedString)
        //{
        //    // Initialise
        //    AesManaged decryptor = new AesManaged();
        //    byte[] encryptedData = Convert.FromBase64String(encryptedString);

        //    // Set the key
        //    decryptor.Key = key;
        //    decryptor.IV = key;

        //    // create a memory stream
        //    using (MemoryStream decryptionStream = new MemoryStream())
        //    {
        //        // Create the crypto stream
        //        using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //        {
        //            // Encrypt
        //            decrypt.Write(encryptedData, 0, encryptedData.Length);
        //            decrypt.Flush();
        //            decrypt.Close();

        //            // Return the unencrypted data
        //            byte[] decryptedData = decryptionStream.ToArray();
        //            return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
        //        }
        //    }
        //}

       
    }
    public enum UserRole
    {
        Admin,
        Client

    }
}