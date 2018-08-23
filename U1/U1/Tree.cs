using System;
using System.Collections.Generic;
using IV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U1
{
    [TestClass]
    public class Tree
    {
        [TestMethod]
        public void Inorder()
        {
            var b = BinaryTree.SetSampleData2();
            b.InOrder(b.Root);
            CollectionAssert.AreEqual(new List<int>(){ 3, 12, 6, 4, 7, 10, 11, 5, 2, 8 }, b.InOrderList);
        }

        [TestMethod]
        public void Heapsort()
        {
            var h = new HeapSort();
            var actual = new List<int>(HeapSort.ResultList);
            var t = actual[2];
            actual[2] = actual[6];
            actual[6] = t;
            actual.Sort();
            CollectionAssert.AreEqual(actual, HeapSort.ResultList);
        }
    }
}
