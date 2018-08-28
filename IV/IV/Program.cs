using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace IV
{
    class Program
    {
        
        public static void Main()
        {
            new BinarySearchPos2();
        }

        public static void print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
        
    }
    public class AllPossibleSums
        {
            public static int limit = 10;
            public static int calls = 0;
            public static HashSet<int> included = new HashSet<int>();
            public static List<List<int>> set = new List<List<int>>();

            public AllPossibleSums()
            {
                test(new List<int>() { 1, 2, 3, 4, 5, 6, 7 }, 0, -1, "start", new List<int>());
                Console.WriteLine("RESULT: ");
//                set.ForEach(display);
                Console.ReadKey();
            }
            public static void test(List<int> original, int current, int ic, string message, List<int> append, bool displayIt = false)
            {
                calls++;
                Console.WriteLine($"ic :{ic}, current :{current}, message:{message}, calls: {calls}");
                if (current <= limit && displayIt)
                {
//                display(append);
                    set.Add(new List<int>(append));
                    displayIt = false;
                }
                else
                {
                    Console.WriteLine("Null");
                }
                if (ic == original.Count - 1)
                {
                    return;
                }

                ic++;

                test(original, current, ic, "just current " + current + " for " + original[ic], new List<int>(append), displayIt);
                if (!append.Contains(original[ic]))
                {
                    displayIt = true;
                    append.Add(original[ic]);
                }
                test(original, original[ic] + current, ic, original[ic] + " plus " + current, new List<int>(append), displayIt);

            }
        }
}
