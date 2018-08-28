using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //This one works way better!
    class BinarySearchPos2
    {
        public static int found = -1;
        public BinarySearchPos2()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            findx(arr, 1, 0, arr.Length);

            if (found != -1)
            {
                Console.WriteLine($"Found at position {found}");
            }
            Console.ReadKey();
        }
        public static void findx(int[] arr, int find, int start, int end)
        {
            var mid = (end + start) / 2;
            if (arr[mid] == find)
            {
                Console.WriteLine("found it " + mid);
                found = mid;
                return;
            }
            if (Math.Abs(start - end) == 1)
            {
                Console.WriteLine("Cannot find");
                return;
            }
            if (arr[mid] > find)
            {
                findx(arr, find, 0, mid);
            }
            else
            {
                findx(arr, find, mid, end);
            }
        }
    }
}
