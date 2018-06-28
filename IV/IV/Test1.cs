using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //I MIGHT BE WRONG, BUT THE EXAMPLE GIVEN DOESN'T SEEM CORRECT
    //11 1111 1111 1111 1111 1111 0111 1111, SHOULD NOT CONFORM WITH
    //11 1111 1111 1111 1111 1111 1001 1111, THIS A SINCE 1XX1
    //11 1111 1111 1111 1111 1111 0011 1111, THIS B SINCE 0X11
    //11 1111 1111 1111 1111 1111 0110 1111, THIS C SINCE 011X
    //BUT THE EXAMPLE SAYS THAT IT DOES!?
    class Solution
    {
        int unmatchStart = -1;
        int unmatchEnd = -1;

        public int solution(int A, int B, int C)
        {
            var AbitString = Convert.ToString(A, 2);
            var BbitString = Convert.ToString(B, 2);
            var CbitString = Convert.ToString(C, 2);
            var Abit = AbitString.PadLeft(32, '0').ToCharArray();
            var Bbit = BbitString.PadLeft(32, '0').ToCharArray();
            var Cbit = CbitString.PadLeft(32, '0').ToCharArray();
            
            for(int i = 0; i < Abit.Length; i++)
            {
                if(Abit[i] != Bbit[i])
                {
                    setUnmatch(i);
                }
                if (Bbit[i] != Cbit[i])
                {
                    setUnmatch(i);
                }
                if (Abit[i] != Cbit[i])
                {
                    setUnmatch(i);
                }
            }

            var bitDiffLength = unmatchEnd - unmatchStart;
            var totalPerm = Math.Pow(2, unmatchEnd - unmatchStart);

            var largest = new string('1', bitDiffLength+1);
            var largestNum = Convert.ToInt32(largest, 2);

            var insertBinarys = new List<string>();

            for(int i = 0; i < largestNum + 1; i++)
            {
                insertBinarys.Add(Convert.ToString(i, 2).PadLeft(4, '0'));
            }

            var possibles = new List<string>();

            insertBinarys.ForEach(e =>
            {
                var add = combine(AbitString, e, unmatchStart, unmatchEnd);
                possibles.Add(add);
            });

            var conformers = new List<string>();

            possibles.ForEach(e =>
            {
                if (isConform(AbitString, e))
                {
                    if(!conformers.Contains(e))
                        conformers.Add(e);
                }
                if (isConform(BbitString, e))
                {
                    if (!conformers.Contains(e))
                        conformers.Add(e);
                }
                if (isConform(CbitString, e))
                {
                    if (!conformers.Contains(e))
                        conformers.Add(e);
                }
            });

            var conformerInt = new List<int>();

            conformers.ForEach(e =>
            {
                conformerInt.Add(Convert.ToInt32(e.PadLeft(32, '0'), 2));
            });

            return conformerInt.Count;
        }
        private bool isConform(string original, string test)
        {
            //Console.WriteLine("original: test");
            //Console.WriteLine(original);
            //Console.WriteLine(test);
            for(int i = 0; i < original.Length; i++)
            {
                if(test[i] == '1')
                {
                    if(original[i] == '0')
                    {
                        //Console.WriteLine("FAILED");
                        return false;
                    }
                }
            }
            //Console.WriteLine("PASS");
            return true; //test is 0
        }
        private string combine(string fix, string insert, int start, int end)
        {
            var stringBinary = new StringBuilder(fix);
            //Console.WriteLine("fix length: " + fix.Length);
            //Console.WriteLine("insert before:" + fix);
            //Console.WriteLine("insert at:" + start);
            //Console.WriteLine("insert with:" + insert);
            start = start - 2;
            end = end - 2;
            var removeDiff = end - start + 1;
            stringBinary.Remove(start, removeDiff);
            stringBinary.Insert(start, insert);
            var returnValue = stringBinary.ToString();
            //Console.WriteLine("insert after :" + returnValue);
            return returnValue;
        }
        private void setUnmatch(int position)
        {
            if(unmatchStart == -1)
            {
                unmatchStart = position;
            }
            else
            {
                unmatchEnd = position;
            }
        }
    }
}
