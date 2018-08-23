using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //https://www.geeksforgeeks.org/find-pythagorean-triplet-in-an-unsorted-array/
    public class PythagoreanTriplet
    {
        public List<int> arr = new List<int>() { 3, 1, 4, 6, 5 };
        public PythagoreanTriplet()
        {
            arr.Sort();
            var ans = new[] { -1, -1, -1 };
            var hasAns = false;
            for (var i = 0; i < arr.Count; i++)
            {
                for (var j = 0; j < arr.Count; j++)
                {
                    var test = arr[i] * arr[i] + arr[j] * arr[j];
                    foreach (var e in arr)
                    {
                        if (test == e * e)
                        {
                            ans[0] = arr[i];
                            ans[1] = arr[j];
                            ans[2] = e;
                            hasAns = true;
                        }
                    }
                    if (hasAns) break;
                }
                if (hasAns) break;
            }

            foreach (var x in ans)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }
    }
}
