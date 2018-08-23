using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    public class BitRotation
    {
        public readonly int RotatedBit;
        public readonly string RotatedBitString;
        public readonly string OriginalBitString;
        public BitRotation(int bit, int rotationIndex)
        {
            //Get to string form
            OriginalBitString = Convert.ToString(bit, 2);
            var totalLength = OriginalBitString.Length;

            //start pushing
            var leftPush = bit << rotationIndex;
            var rightPush = bit >> totalLength - rotationIndex;

            //since pushing left will add 0 to the end, need to cut off the non-zero ends
            var leftIntString = Convert.ToString(leftPush, 2).Substring(rotationIndex, totalLength);
            var leftInt = Int32.Parse(leftIntString);

            //since pushing right, all the right sides are deleted
            var rightIntString = Convert.ToString(rightPush, 2);
            var rightInt = Int32.Parse(rightIntString);

            //right side will merge with left side at the zeros tail
            RotatedBit = leftInt + rightInt;
            RotatedBitString = RotatedBit.ToString();
        }
    }
}
