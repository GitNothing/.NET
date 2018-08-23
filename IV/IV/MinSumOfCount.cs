using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //returns a set of list of elements that does not sum over the limit. Return list is unique.
    //More general version of https://www.geeksforgeeks.org/count-triplets-with-sum-smaller-that-a-given-Value/
    class MinSumOfCount
    {
        public MinSumOfCount(int[] arr, int limit = 12, int countOf = 3)
        {
            if (arr == null)
            {
                arr = new[] { 5, 1, 3, 4, 7 };
            }
            limit = 12;
            countOf = 3;

            var l = arr.ToList();
            l.Sort();
            arr = l.ToArray();

            var current = 0;
            var currents = new List<int>();
            var sets = new List<int[]>();
            var currentCheckable = new List<int>();

            for (var j = 0; j < arr.Length; j++)
            {
                current = 0;
                currents.Clear();
                currentCheckable.Clear();
                Console.WriteLine("Current:");
                print(arr);
                for (var i = 0; i < arr.Length; i++)
                {
                    //check limit before adding
                    if (current + arr[i] < limit)
                    {
                        //add to check if unique
                        currentCheckable.Add(arr[i]);
                        if (isUnique(sets, currentCheckable))
                        {
                            currents.Add(arr[i]);
                            current += arr[i];
                        }
                        else
                        {
                            //remove if not unique, then continue to next element
                            currentCheckable.Remove(arr[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("reject since over limit: " + arr[i]);
                    }
                }
                print(currents.ToArray());
                currents.Sort(); //add to set as sorted
                if (currents.Any() && currents.Count == countOf) sets.Add(currents.ToArray());

                //shift array
                arr = shift(arr);
            }

            Console.WriteLine("Sets: ");
            sets.ForEach(print);
            Console.ReadKey();
        }

        private void print(int[] arr)
        {
            Console.WriteLine();
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].ToString() + ",");
            }
            Console.WriteLine();
        }

        //check if an array is unique in the set
        private bool isUnique(List<int[]> sets, List<int> test)
        {
            if (!sets.Any()) return true;
            var l = test.ToList();
            var unique = true;
            sets.ForEach(e => {
                //if all elements in e can be matched with all element in test, then it is not unique
                if (e.Intersect(test).ToList().Count == e.Length)
                {
                    unique = false;
                    Console.WriteLine("Not unique");
                    print(test.ToArray());
                }
            });
            return unique;
        }
        private int[] shift(int[] arr)
        {
            var l = new List<int>();
            for (var i = 1; i < arr.Length; i++)
            {
                l.Add(arr[i]);
            }
            l.Add(arr[0]);
            return l.ToArray();
        }
    }
}
