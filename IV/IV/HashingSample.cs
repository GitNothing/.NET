using System.Linq;
using System.Security.Cryptography;

namespace IV
{
    class HashingSample
    {
        public HashingSample()
        {
            //data to work with
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 2, 2, 3, 4, 5, 3, 2, 1, 2, 3 };

            #region General algorithm will produce same hash

            var hashMaker1 = new SHA256Managed();
            var hash1 = hashMaker1.ComputeHash(data);

            var hashMaker2 = new SHA256Managed();
            var hash2 = hashMaker2.ComputeHash(data);

            var shouldEqual = hash1.SequenceEqual(hash2);

            #endregion

            #region HMAC hash will only produce same hash if the secret is the same

            var secret = new byte[] { 1, 2, 3, 4, 5 };
            var HMAChashMaker1 = new HMACSHA256(secret);
            var hashA1 = HMAChashMaker1.ComputeHash(data);

            var HMAChashMaker2 = new HMACSHA256(secret);
            var hashA2 = HMAChashMaker2.ComputeHash(data);

            var shouldNotEqual = hash1.SequenceEqual(hashA1); //different hash then general algorithm
            var shouldEqual2 = hashA1.SequenceEqual(hashA2);

            #endregion

            //Using a different secret will produce a different hash when using HMAC
            var secret2 = new byte[] { 1, 2, 3, 4, 6 };
            var HMAChashMaker3 = new HMACSHA256(secret2);
            var hashA3 = HMAChashMaker3.ComputeHash(data);
            var shouldNotEqual2 = hashA1.SequenceEqual(hashA3);
        }
    }
}
