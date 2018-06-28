using System.Collections.Generic;

namespace IV
{
    public class bubbleSort: Sort
    {
        public bubbleSort(List<int> list)
        {
            original = list;
            common.print(original);
            sort(0, original.Count - 1);
            common.print(original);
        }
        private void sort(int start, int end)
        {
            for(int i = start; i < end; i++)
            {
                for (int j = start; j < end; j++)
                {
                    if(original[j] > original[j+1])
                    {
                        common.swap(ref original, j, j+1);
                    }
                }
            }
        }
    }
}
