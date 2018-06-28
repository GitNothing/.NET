using System;
using System.Collections.Generic;

namespace IV
{
    public class common
    {
        public static void swap(ref List<int> _list, int x, int y)
        {
            Console.WriteLine("=== Swap " + x + " " + y + " ===");
            Console.Write("BEFORE ");
            print(_list);
            var tmp = _list[x];
            _list[x] = _list[y];
            _list[y] = tmp;
            Console.Write("AFTER ");
            print(_list);
        }
        public static void print(List<int> _list, int start = -1, int end = -1)
        {
            if(start == -1 || end == -1)
            {
                start = 0;
                end = _list.Count - 1;
            }
            for (int i = start; i < end + 1; i++)
            {
                Console.Write(_list[i] + "-");
            }
            Console.WriteLine();
        }
        public static List<int> randomList(int length = 10, int start = 20, int end = 100)
        {
            var l = new List<int>();
            var c = new Random();
            for (int i = 0; i < length; i++)
            {
                l.Add(c.Next(start, end));
            }
            return l;
        }
    }
}
