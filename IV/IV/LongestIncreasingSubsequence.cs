using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    public class LongestIncreasingSubsequence
    {
        private List<int> List { get; set; }
        private List<int> WorkingList = new List<int>();
        public List<int> Result { get; set; }

        public LongestIncreasingSubsequence(List<int> list = null)
        {
            if (list == null)
            {
                List = new List<int>() { 3, 4, -1, 0, 6, 2, 3 }; //sample data, result should be -1,0,2,3
            }
            else
            {
                List = list;
            }

            for (int i = 0; i < List.Count; i++)
            {
                WorkingList.Add(1);
            }
            Check(0, 0);
            Result = GetSequence();
        }
        private void Check(int j, int i)
        {
            if (i == WorkingList.Count) return; //finish
            if (i == 0) //Just started
            {
                Check(j, i + 1);
                return;
            };

            //If next value is greater
            if (List[j] < List[i])
            {
                //Only update the ith index if it is less than or equal to the jth index
                if (WorkingList[j] >= WorkingList[i])
                {
                    WorkingList[i] = WorkingList[i] + 1;
                    Check(j + 1, i);
                }
                else
                {
                    Check(0, i + 1);
                }
            }
            else
            {
                //keep moving j if ith is not greater, reset j if position is equal to i
                if (j == i)
                {
                    Check(0, i + 1);
                }
                else
                {
                    Check(j + 1, i);
                }
            }
        }

        private List<int> GetSequence()
        {
            //copy the WorkingList, then sort and dedupe
            var result = new List<int>();
            var order = new List<int>(WorkingList);
            order.Sort();
            var dedupe = order.Distinct().ToList();

            //for each unique value of WorkingList
            for (int i = 0; i < dedupe.Count; i++)
            {
                result.Add(-1);
                //Go through each WorkingList
                for (int k = 0; k < WorkingList.Count; k++)
                {
                    //if a value in the WorkingList matches the dedupe value then replace with the previously value that was assign to the result
                    //replace with value of the kth on the original List[kth]
                    if (WorkingList[k] == dedupe[i]) result[result.Count - 1] = List[k];
                }
            }
            return result;
        }
    }
}
