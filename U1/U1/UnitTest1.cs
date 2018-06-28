using IV;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace U1
{
    [TestClass]
    public class UnitTest1
    {
        List<int> list = common.randomList();

        [TestMethod]
        public void quickSort()
        {
            var c = new QuickSort(list);
            CollectionAssert.AreEqual(list.OrderBy(d => d).ToList(), c.getResult());
        }
        [TestMethod]
        public void bubbleSort()
        {
            var c = new bubbleSort(list);
            CollectionAssert.AreEqual(list.OrderBy(d => d).ToList(), c.getResult());
        }
        [TestMethod]
        public void mergeSort()
        {
            var c = new MergeSort(list);
            CollectionAssert.AreEqual(list.OrderBy(d => d).ToList(), c.getResult());
        }
    }
}
