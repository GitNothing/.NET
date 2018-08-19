using System;
using System.Linq;
using System.Security.Cryptography;

namespace IV
{
    class SymmetricSample
    {
        public SymmetricSample()
        {
            //This uses block-chaining method
            //data to work with
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 5, 3, 2, 1, 2, 3 };
            SymmetricAlgorithm c = SymmetricAlgorithm.Create();

            //generate key and IV
            var iv = c.IV;
            var key = c.Key;

            //encrypt
            var encry = c.CreateEncryptor(); //automatically use the keys found in c.
            var finalBlock = encry.TransformFinalBlock(data, 0, data.Length);

            //decrypt
            var decry = c.CreateDecryptor(key, iv); //could automatically use the keys already in c.
            var finalBlockD = decry.TransformFinalBlock(finalBlock, 0, finalBlock.Length);

            if (finalBlockD.SequenceEqual(data))
            {
                Console.WriteLine("Encryption test successful.");
            }
            else
            {
                Console.WriteLine("Encryption test has failed.");
            }
        }
    }
}
