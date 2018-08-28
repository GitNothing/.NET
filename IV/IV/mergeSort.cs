/*
    This is my C# implementation of the merge sort algorithm. 

    REFERENCE: https://www.geeksforgeeks.org/merge-sort/

    NOTE: “common.print(someArray) and common.swap(ref someArray, index1, index2)” belongs to another static class call "common" that is often use by my other sorting algorithms, like quick sort, bubble sort, etc… 

    UNIT TEST BELOW
*/

using System;
using System.Collections.Generic;

namespace IV
{
    public class MergeSort: Sort
    {
        //Merge into this array, and stores into original for every division.
        List<int> merger = new List<int>();

        public MergeSort(List<int> inputList)   
        {
            original = inputList;
            common.print(original); 
            sort();
            common.print(original);
        }
        private void sort()
        {
            int div = 1; //1, since the array is completely split from the start, then doubles after every division.
            int pointer = 0;

            //While the division (div) size is less than the total original count.
            while(div < original.Count)
            {
                pointer = 0; //Resets pointer after each merge cycle.
                merger.Clear(); //Reset merge array for next cycles.

                while (pointer < original.Count) //Move pointer over every element.
                {

                    //Each merge will have only two arrays
                    var Array1 = new List<int>();
                    var Array2 = new List<int>();

                    //create array for each part by current division length
                    //part1
                    for (int i = 0; i < div; i++)
                    {
                        //Don't add if pointer exceeds array size
                        if (pointer < original.Count)
                        {
                            Array1.Add(original[pointer]);
                            pointer++;
                        }
                    }

                    //part2
                    for (int i = 0; i < div; i++)
                    {
                        //Don't add if pointer exceeds array size
                        if (pointer < original.Count)
                        {
                            Array2.Add(original[pointer]);
                            pointer++;
                        }
                    }

                    //Merge both array and add to the merge array
                    addMerger(merge(Array1, Array2));

                }//merge another pair of array in the current div if there are elements left

                //Copy the current merge array to the original array
                original = new List<int>(merger);

                div *= 2; //Next division is double the last
            }
        }

        //Adds any array to the merge array
        private void addMerger(List<int> list)
        {
            list.ForEach(e =>
            {
                merger.Add(e);
            });
        }

        //merge any two array of any size and return as one array
        //will merge sorted
        private List<int> merge(List<int> list1, List<int> list2)
        {
            //if one of the list is empty, it returns the other list in full.
            if (list2.Count == 0) return list1;
            if (list1.Count == 0) return list2;

            //returns this list with the sorted numbers
            var mergeArray = new List<int>();

            var pointer1 = 0;
            var pointer2 = 0;
            var end1 = false;
            var end2 = false;

            while(!end1 || !end2)
            {
                //add conditionally by moving pointers
                if(list1[pointer1] <= list2[pointer2]) //adds from list1 and moves forward pointer1
                {
                    if(!end1)mergeArray.Add(list1[pointer1]); //if pointer reached end, don't add

                    if (pointer1 < list1.Count-1)
                    {
                        pointer1++;
                    }
                    else
                    {
                        end1 = true;
                    }
                }
                else //adds from list2 and moves forward pointer2
                {
                    if (!end2) mergeArray.Add(list2[pointer2]); //if pointer reached end, don't add
                    if (pointer2 < list2.Count-1)
                    {
                        pointer2++;
                    }
                    else
                    {
                        end2 = true;
                    }
                }

                //add the rest if one of the pointer have reached end
                if (end1 && !end2) //add the rest from list2
                {
                    mergeArray.Add(list2[pointer2]);
                    if (pointer2 < list2.Count - 1)
                    {
                        pointer2++;
                    }
                    else
                    {
                        end2 = true;
                    }
                }
                if (end2 && !end1) //add the rest from list1
                {
                    mergeArray.Add(list1[pointer1]);
                    if (pointer1 < list1.Count - 1)
                    {
                        pointer1++;
                    }
                    else
                    {
                        end1 = true;
                    }
                }
                common.print(mergeArray);
            }
            return mergeArray;
        }
    }
}


//[TestMethod]
//public void mergeSort()
//{
//    var c = new MergeSort(list);
//    CollectionAssert.AreEqual(list.OrderBy(d => d).ToList(), c.getResult());
//}

/*

Test Name:	mergeSort
Test FullName:	U1.UnitTest1.mergeSort
Test Source:	C:\Users\viluan\Desktop\ReposSync\NET\IV\U1\U1\UnitTest1.cs : line 26
Test Outcome:	Passed
Test Duration:	0:00:00.0015058

Result StandardOutput:	
55-70-53-55-82-32-25-76-98-83-
55-70-
53-55-
32-82-
25-76-
83-98-
53-
53-55-
53-55-55-70-
25-
25-32-
25-32-76-82-
25-
25-32-
25-32-53-
25-32-53-55-
25-32-53-55-55-
25-32-53-55-55-70-76-
25-32-53-55-55-70-76-82-
25-
25-32-
25-32-53-
25-32-53-55-
25-32-53-55-55-
25-32-53-55-55-70-
25-32-53-55-55-70-76-
25-32-53-55-55-70-76-82-83-
25-32-53-55-55-70-76-82-83-98-
25-32-53-55-55-70-76-82-83-98-
Display result:
25-32-53-55-55-70-76-82-83-98-

*/
