using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//COULD NOT SOLVE THIS
//https://www.geeksforgeeks.org/generate-all-possible-sorted-arrays-from-alternate-elements-of-two-given-arrays/

namespace IV
{
    class AlterArray
    {
        public static int[] a;
        public static int[] b;
        public static List<List<int>> resultSet = new List<List<int>>();
        public static List<int> current = new List<int>();
        public static int starter = -1;
        public AlterArray()
        {
            a = new int[] { 10, 15, 25 };
            b = new int[] { 1, 5, 20, 30 };
            var ACompleted = false;
            var BCompleted = false;
            var current = new List<int>();
            var iA = 0;
            var iB = 0;
            var iStart = 0;
            var isA = false;
            current.Add(a[iA]);
            check(a.Length, b.Length, false);
        }

        public static void check(int iA, int iB, bool isA)
        {
            var wasTracked = false;
            if (isUnique(resultSet, current))
            {
                resultSet.Add(new List<int>(current));
                wasTracked = true;
            }

            if (iA >= a.Length - 1 && iB >= b.Length - 1 && !wasTracked)
            {
                starter++;
                iB = 0;
                current.Add(a[starter]);
                iA = starter;
                isA = false;
            }

            if (iA >= a.Length)
            {
                iA = 0;
                isA = false;
            }

            if (iB >= b.Length)
            {
                iB = b.Length;
            }

            if (isA)
            {
                if (a[iA] > current[current.Count - 1])
                {
                    current.Add(a[iA]);
                    check(iA, iB + 1, false);
                }
                else
                {
                    check(iA + 1, iB, true);
                }
            }
            else
            {
                if (b[iB] > current[current.Count - 1])
                {
                    current.Add(b[iB]);
                    check(iA + 1, iB, true);
                }
                else
                {
                    check(iA, iB + 1, false);
                }
            }
        }
        public static void print(List<int> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ",");
            }
        }
        public static bool isUnique(List<List<int>> resultSet, List<int> test)
        {
            if (test.Count % 2 != 0) return false;
            if (!test.Any()) return false;
            foreach (var e in resultSet)
            {
                var ins = e.Intersect(test).ToList();
                if (current.Intersect(e).ToList().Count == current.Count && e.Count == current.Count)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Not unique");
                    return false;
                    break;
                }
            }
            return true;
        }
    }
}
