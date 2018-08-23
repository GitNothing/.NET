using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //Binary search and also tracks position
    public class BinarySearchPos
    {
        private int find = 7;
        private int finalPosition = -1;
        private List<int> sample = new List<int>() { 3, 4, 53, 7, 4, 2, 1, 9 }; //5 start at 0
        private List<int> sample1 = new List<int>() { 3, 2, 5, 10, 3, 54, 7, 23, 4, 100 }; //5 start at 0
        //1,2,3,4,4,7,9,53
        public BinarySearchPos()
        {
            sample1.Sort();
            print(sample1);
            Binary(sample1);
            Console.WriteLine("Position " + finalPosition);
            Console.ReadKey();
        }
        private int Binary(List<int> current, int position = -1)
        {
//                Console.WriteLine("current position: " + position);
            if (current.Count == 1)
                if (current[0] == find) return finalPosition = position + 1;
            var half = current.Count / 2;
            var left = new List<int>();
            var right = new List<int>();
            for (int i = 0; i < half; i++)
            {
                left.Add(current[i]);
            }

            for (int i = half; i < current.Count; i++)
            {
                right.Add(current[i]);
            }

            if (left[left.Count - 1] >= find)
            {
//                    Console.WriteLine($"Reduce {0}, go left");
                print(left);
                Binary(left, position);
            }
            else
            {
//                    Console.WriteLine($"Add {right.Count}, go right");
                print(right);
                Binary(right, position + right.Count);
            }
            return -1;
        }

        private void print(List<int> list)
        {
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ",");
            }
        }
    }
}
