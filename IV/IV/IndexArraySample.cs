using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    public class IndexArraySample
    {
        public int this[int index]
        {
            get
            {
                if (_myIndex != null) return _myIndex[index];
                return -1;
            }
            set
            {
                if(_myIndex == null) _myIndex = new List<int>();
                while (_myIndex.Count < index+1)
                {
                    Console.WriteLine("index filling " + _myIndex.Count);
                    _myIndex.Add(-1);
                }

                _myIndex[index] = value;
            }
        }
        private List<int> _myIndex;

        //usage
        //var i = new IndexArraySample();
        //i[20] = 1123;
        //Console.WriteLine(i[19]); //prints -1
        //Console.WriteLine(i[20]); //prints 1123
    }
}
