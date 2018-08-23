using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    class StockBuySell
    {
        public List<int> arr = new List<int>() { 100, 2, 260, 310, 40, 535, 2 };
        //expected result, buy at 1,4. Sell at 0,3,5.
        public List<int> buy = new List<int>();
        public List<int> sell = new List<int>();
        public StockBuySell()
        {
            check(0, true);
            //set debug point at check to see the buy and sell result
        }
        public void check(int index, bool isHigh)
        {
            if (index + 1 == arr.Count)
            {
                if (isHigh)
                {
                    sell.Add(index);
                }
                return;
            }
            if (arr[index + 1] > arr[index])
            {
                if (!isHigh)
                {
                    buy.Add(index);
                }
                check(index + 1, true);
            }
            else
            {
                if (isHigh)
                {
                    sell.Add(index);
                }
                check(index + 1, false);
            }
        }
    }
}
