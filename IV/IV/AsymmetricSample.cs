using System;
using System.Security.Cryptography;

namespace IV
{
    class AsymmetricSample
    {
        public AsymmetricSample()
        {
            //data to work with
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 5, 3, 2, 1, 2, 3 };

            //get the keys
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            var publicK = RSA.ToXmlString(false);
            var privateK = RSA.ToXmlString(true);

            //private encryption
            var dataEncrypted = RSA.Encrypt(data, true);

            //public encryption, using another RSA object
            var RSAOverride = new RSACryptoServiceProvider();
            RSAOverride.FromXmlString(publicK);
            var dataEncryptedPublicily = RSAOverride.Encrypt(data, true);

            //decrypting with private key
            RSAOverride.FromXmlString(privateK);
            var dataDecryptPrivately = RSAOverride.Decrypt(dataEncrypted, true);

            //decrypting with public key
            try
            {
                RSAOverride.FromXmlString(publicK);
                var dataDecryptPublicily = RSAOverride.Decrypt(dataEncrypted, true);
            }
            catch
            {
                Console.WriteLine("Should not work");
            }

            //decrypting data that was encrypted with public key, done privately
            RSAOverride.FromXmlString(privateK);
            var dataDecryptPrivately2 = RSAOverride.Decrypt(dataEncryptedPublicily, true);

            //decrypting data that was encrypted with public key, done pubicily
            try
            {
                RSAOverride.FromXmlString(publicK);
                var dataDecryptPublicily2 = RSAOverride.Decrypt(dataEncryptedPublicily, true);
            }
            catch
            {
                Console.WriteLine("Should also not work");
            }
        }
    }
}
