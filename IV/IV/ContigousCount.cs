using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //NOT solved
    class ContigousCount
    {
        public ContigousCount(int[] sample)
        {
            if(sample == null) sample = new[] { 1, 56, 58, 57, 90, 92, 94, 93, 91, 45 }; //test sample should equal 5

            var tracker = new List<int>();
            tracker.Add(sample[0]);
            var sets = new List<List<int>>();
            for (int i = 1; i < sample.Length; i++)
            {
                var current = sample[i];
                var diff = Math.Abs(current - tracker[tracker.Count - 1]);
                if (diff == 1)
                {
                    tracker.Add(sample[i]);
                }
                else
                {
                    sets.Add(new List<int>(tracker));
                    tracker.Clear();
                    tracker.Add(sample[i]);
                }
            }
            if (tracker.Any()) sets.Add(new List<int>(tracker));
            var count = 0;
            sets.ForEach(e =>
            {
                if (e.Count > count && e.Count > 1) count = e.Count;
            });
            Console.WriteLine("Max contigous " + count);
            Console.ReadKey();
        }
    }
}
