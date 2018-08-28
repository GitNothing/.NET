using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    //Use for various sorting methods. This is kept in a seperate file.
    public abstract class Sort
    {
        protected List<int> original; //The array that the user wants to be sorted.
        public List<int> getResult() //Returns the sorted array.
        {
            Console.WriteLine("Display result:");
            common.print(original); //This basically console out an array in a readable format.
            return original;
        }
    }
}
