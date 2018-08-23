using System;
using System.Collections.Generic;
using System.Linq;

namespace IV
{
    //https://www.youtube.com/watch?v=PqS5T9ZKZno&t=654s

    public class HeapSort
    {
        //These three are only use by transversal method
        public static List<int> outputNum = new List<int>();
        public static List<BinaryNode> Nodes = new List<BinaryNode>();
        public static List<int> ResultList;
        public static string result = "";

        //These two are use by heapsort
        public static List<int> Checked = new List<int>();
        public static List<BinaryNode> NodesOrder;
        public HeapSort()
        {
            var tree = BinaryTree.SetSampleData3();
            InOrder(tree.Root);
            NodesOrder = new List<BinaryNode>(tree.NodesTreeIndex); //Tree ordered list
            Process(NodesOrder.Count);

            Console.WriteLine("Sorted Result: ");
            ResultList = NodesOrder.Select(e => e.Num).ToList();
        }

        private void Process(int current)
        {
            //Rebalance -> Add first, swap first with last by tree order
            Rebalance(NodesOrder);
            Console.WriteLine("");
            Console.WriteLine("Rebalance");
            BinaryTree.PrintNode(NodesOrder);
            Checked.Add(NodesOrder[0].Num);
            if (NodesOrder[0].Num > NodesOrder[current - 1].Num)
                NodeValueSwap(NodesOrder[0], NodesOrder[current - 1]);
            Console.WriteLine("");
            Console.WriteLine("Current");
            BinaryTree.PrintNode(NodesOrder);
            if (current > 1)
            {
                Process(current-1);
            }
            else
            {
                return;
            }
        }
        private void Rebalance(List<BinaryNode> list)
        {
            var hasSwap = false;
            foreach (var i in list)
            {
                if (i.Left != null || i.Right != null)
                {
                    if (Unswappable(i.Left.Num, i.Right.Num, i.Num)) continue;

                    //Exchange with child node if one is larger than current parent node
                    if (i.Left.Num > i.Num || i.Right.Num > i.Num)
                    {
                        if (i.Left.Num > i.Right.Num)
                        {
                            NodeValueSwap(i, i.Left);
                        }
                        else
                        {
                            NodeValueSwap(i, i.Right);
                        }
                        hasSwap = true;
                    }
                }
            }

            //Look through the tree again if a swap has occured to make sure other nodes need swapping
            if (hasSwap)
            {
                Rebalance(list);
            }
            return;
        }

        //Will not swap if one of these values are already in the Checked list
        private bool Unswappable(int left, int right, int main)
        {
            var notOkay = Checked.FindAll(e => e == left || e == right || e == main).Count >
                     0;
            return notOkay;
        }

        //Swap Node by their Value
        private void NodeValueSwap(BinaryNode n1, BinaryNode n2)
        {
            var t = n1.Num;
            n1.Num = n2.Num;
            n2.Num = t;
//            Console.WriteLine($"Swap {n1.Num}:{n2.Num}");
        }

        #region Transveral
        //Transverse to find the list
        private void InOrder(BinaryNode current)
        {
            //keep moving down
            if (current == null) return;
            if (current.Left != null)
            {
                if (!has(current.Left.Num))
                {
                    InOrder(current.Left);
                }
                else
                {
                    if (!has(current.Num))
                    {
                        result = result + current.Num + ",";
                        Console.WriteLine("Adding " + current.Num);
                        Nodes.Add(current);
                        outputNum.Add(current.Num);
                        InOrder(current.Right);
                    }
                    else
                    {
                        InOrder(current.Parent);
                    }
                }
            }
            else
            {
                if (!has(current.Num))
                {
                    result = result + current.Num + ",";
                    Console.WriteLine("Adding " + current.Num);
                    Nodes.Add(current);
                    outputNum.Add(current.Num);
                    InOrder(current.Parent);
                }
                else
                {
                    InOrder(current.Parent);
                }
            }
        }

        private bool has(int n)
        {
            if (outputNum.Contains(n))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
