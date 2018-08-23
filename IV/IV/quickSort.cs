/*
    This is my C# implementation of the quick sort algorithm.

    REFERENCE: https://www.youtube.com/watch?v=MZaf_9IZCrc

    NOTE: “common.print(someArray) and common.swap(ref someArray, index1, index2)” belongs to another static class call "common" that is often use by my other sorting algorithms, like quick sort, bubble sort, etc… 

    UNIT TEST BELOW
*/

using System;
using System.Collections.Generic;

namespace IV
{
    public class QuickSort: Sort
    {
        public QuickSort(List<int> inputList)
        {
            original = inputList;
            common.print(original);
            sort(0, original.Count-1);
            common.print(original);
        }
        private void sort(int start, int end)
        {
            //Conditions of no sort
            if (end < start) return;
            if (start == end) return;

            Console.WriteLine("\n======= SORT =======");

            //Set pointer to starting point
            int pointer1 = start-1;
            int pointer2 = start;

            //Set pivot and its Value to compare
            int pivot = end; //Use last Value as the pivot
            int comparer = original[pivot];

            Console.WriteLine("Pivot Value " + comparer);
            Console.WriteLine("Stop point " + (end - 1));

            Console.Write("Sort parition ");
            common.print(original, start, end);

            while (pointer2 < end)
            {
                Console.WriteLine("pointer1 " + pointer1 + " pointer2 " + pointer2);

                //Move pointer2 forward if its Value is greater than the pivot.
                if (original[pointer2] > comparer)
                {
                    pointer2++;
                }
                //Otherwise, move pointer1++ and swap with pointer2 Value, then advance pointer2++
                else
                {
                    pointer1++;

                    //Swaps the index of an array (original). Swap at index pointer1 and pointer2.
                    common.swap(ref original, pointer1, pointer2); 

                    pointer2++;
                }
            }

            //Insert pivot Value at pointer1+1 position
            //Only insert if the Value of the new pivot location is greater than the pivot Value
            var newPivotLocation = pointer1 + 1;
            if(original[newPivotLocation] > original[pivot])
            {
                Console.WriteLine("Insert at " + newPivotLocation);

                //Insert pivot Value at newPivotLocation position
                original.Insert(newPivotLocation, original[pivot]);

                //remove the old pivot Value which was pushed +1 at the end position
                original.RemoveAt(end + 1);
                common.print(original);
            }

            //Sets the next recursion of the left-half and right-half.

            //left half starts at start and end at newPivotLocation-1
            sort(start, newPivotLocation-1);

            //right half starts at newPivotLocation+1 and ends at end
            sort(newPivotLocation + 1, end);

            //NOTE: the original pivot on the current recursion is now in the center, and will not be moved again.
        }
    }
}

//[TestMethod]
//public void quickSort()
//{
//    var c = new QuickSort(list);
//    CollectionAssert.AreEqual(list.OrderBy(d => d).ToList(), c.getResult());
//}

/*

Test Name:	quickSort
Test FullName:	U1.UnitTest1.quickSort
Test Source:	C:\Users\viluan\Desktop\ReposSync\NET\IV\U1\U1\UnitTest1.cs : line 14
Test Outcome:	Passed
Test Duration:	0:00:00.0404203

Result StandardOutput:	
91-86-64-52-64-26-21-29-33-56-

======= SORT =======
Pivot Value 56
Stop point 8
Sort parition 91-86-64-52-64-26-21-29-33-56-
pointer1 -1 pointer2 0
pointer1 -1 pointer2 1
pointer1 -1 pointer2 2
pointer1 -1 pointer2 3
=== Swap 0 3 ===
BEFORE 91-86-64-52-64-26-21-29-33-56-
AFTER 52-86-64-91-64-26-21-29-33-56-
pointer1 0 pointer2 4
pointer1 0 pointer2 5
=== Swap 1 5 ===
BEFORE 52-86-64-91-64-26-21-29-33-56-
AFTER 52-26-64-91-64-86-21-29-33-56-
pointer1 1 pointer2 6
=== Swap 2 6 ===
BEFORE 52-26-64-91-64-86-21-29-33-56-
AFTER 52-26-21-91-64-86-64-29-33-56-
pointer1 2 pointer2 7
=== Swap 3 7 ===
BEFORE 52-26-21-91-64-86-64-29-33-56-
AFTER 52-26-21-29-64-86-64-91-33-56-
pointer1 3 pointer2 8
=== Swap 4 8 ===
BEFORE 52-26-21-29-64-86-64-91-33-56-
AFTER 52-26-21-29-33-86-64-91-64-56-
Insert at 5
52-26-21-29-33-56-86-64-91-64-

======= SORT =======
Pivot Value 33
Stop point 3
Sort parition 52-26-21-29-33-
pointer1 -1 pointer2 0
pointer1 -1 pointer2 1
=== Swap 0 1 ===
BEFORE 52-26-21-29-33-56-86-64-91-64-
AFTER 26-52-21-29-33-56-86-64-91-64-
pointer1 0 pointer2 2
=== Swap 1 2 ===
BEFORE 26-52-21-29-33-56-86-64-91-64-
AFTER 26-21-52-29-33-56-86-64-91-64-
pointer1 1 pointer2 3
=== Swap 2 3 ===
BEFORE 26-21-52-29-33-56-86-64-91-64-
AFTER 26-21-29-52-33-56-86-64-91-64-
Insert at 3
26-21-29-33-52-56-86-64-91-64-

======= SORT =======
Pivot Value 29
Stop point 1
Sort parition 26-21-29-
pointer1 -1 pointer2 0
=== Swap 0 0 ===
BEFORE 26-21-29-33-52-56-86-64-91-64-
AFTER 26-21-29-33-52-56-86-64-91-64-
pointer1 0 pointer2 1
=== Swap 1 1 ===
BEFORE 26-21-29-33-52-56-86-64-91-64-
AFTER 26-21-29-33-52-56-86-64-91-64-

======= SORT =======
Pivot Value 21
Stop point 0
Sort parition 26-21-
pointer1 -1 pointer2 0
Insert at 0
21-26-29-33-52-56-86-64-91-64-

======= SORT =======
Pivot Value 64
Stop point 8
Sort parition 86-64-91-64-
pointer1 5 pointer2 6
pointer1 5 pointer2 7
=== Swap 6 7 ===
BEFORE 21-26-29-33-52-56-86-64-91-64-
AFTER 21-26-29-33-52-56-64-86-91-64-
pointer1 6 pointer2 8
Insert at 7
21-26-29-33-52-56-64-64-86-91-

======= SORT =======
Pivot Value 91
Stop point 8
Sort parition 86-91-
pointer1 7 pointer2 8
=== Swap 8 8 ===
BEFORE 21-26-29-33-52-56-64-64-86-91-
AFTER 21-26-29-33-52-56-64-64-86-91-
21-26-29-33-52-56-64-64-86-91-
Display result:
21-26-29-33-52-56-64-64-86-91-

*/
