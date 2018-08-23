﻿/**
 * Sample of tree tranversal methods
 */

using System;
using System.Collections.Generic;

namespace IV
{
    public class BinaryTree
    {
        public readonly BinaryNode Root;
        public int Count { get; private set; } = 1;
        public List<BinaryNode> NodesTreeIndex { get; set; } = new List<BinaryNode>(); //order by level, left->right

        public BinaryTree(BinaryNode root)
        {
            Root = root;
            NodesTreeIndex.Add(root);
        }

        //You must first run the repective method to generate these list
        public List<int> PreorderList { get; set; } = new List<int>();
        public List<int> PostorderList { get; set; } = new List<int>();
        public List<int> InOrderList { get; set; } = new List<int>();
        public BinaryNode Insert(BinaryNode root, int num, bool isRight = false)
        {
            Count++;
            var n = BinaryNode.Fac(num);
            n.Parent = root;
            if (isRight)
            {
                root.Right = n;
                return n;
            }
            if (root.Left == null)
            {
                //Console.WriteLine(n.num);
                root.Left = n;
            }
            else
            {
                //Console.WriteLine(n.num);
                root.Right = n;
            }

            NodesTreeIndex.Add(n);
            return n;
        }

        //recursively go into the the lower nodes
        public BinaryNode Tran(BinaryNode parent, bool isLeft = true, int times = 0)
        {
            if (times != 0)
            {
                var t = times - 1;
                if (isLeft)
                {
                    return Tran(parent.Left, isLeft, t);
                }
                else
                {
                    return Tran(parent.Right, isLeft, t);
                }
            }
            return parent;
        }

        public void InOrder(BinaryNode current)
        {
            if (current == null) return;

            //keep moving down left;
            if (current.Left != null)
            {
                //left is already tracked
                if (InOrderList.Contains(current.Left.Num))
                {
                    //move to parent if this node is already tracked
                    if (InOrderList.Contains(current.Num))
                    {
                        InOrder(current.Parent);
                        return;
                    }

                    //track current node and move right, since all left node is already tracked
//                    Console.WriteLine($"Add current {current.num}");
                    InOrderList.Add(current.Num);
                    InOrder(current.Right);
                }
                else
                {
                    InOrder(current.Left);
                }
            }

            //can't move down left anymore
            else
            {
                //track current, because can't move down anymore
                if (!InOrderList.Contains(current.Num))
                {
//                    Console.WriteLine($"Add left {current.num}");
                    InOrderList.Add(current.Num);
                }
                else
                {
                    InOrder(current.Parent);
                    return;
                }
                
                //if there is a right and it is not track, move to it
                if (current.Right != null && !InOrderList.Contains(current.Right.Num))
                {
                    InOrder(current.Right);
                }
                else
                {
                    InOrder(current.Parent);
                }
            }
        }

        public void Postorder(BinaryNode current, bool isRightUp = false)
        {
            if (current == null) return;

            //condition to go up on the right nodes
            if (isRightUp)
            {
                if (current.Parent != null) //condition not at root
                {
                    //indicates the end since you cannot come back here more than twice
                    if (PostorderList.Contains(current.Num))
                    {
                        Postorder(null);
                        return;
                    }
//                    Console.WriteLine($"insert from right {current.num}");
                    PostorderList.Add(current.Num);
                    Postorder(current.Parent, true);
                }
                else //condition at root
                {
                    Postorder(current.Right);
                }
                return;
            }
            if (current.Left != null)
            {
                Postorder(current.Left);
            }
            else
            {
                if (!PostorderList.Contains(current.Num))
                {
//                    Console.WriteLine($"insert left {current.num}");
                    PostorderList.Add(current.Num);

                    //go back up to parent and down the next right node
                    Postorder(current.Parent.Right);
                }
                else
                {
                    //go back up to all the right nodes
                    Postorder(current.Parent, true);
                }
            }
        }

        public void Preorder(BinaryNode current)
        {
            if (current == null) return;

            //add node immediately if doesn't exist
            if (!PreorderList.Contains(current.Num)) PreorderList.Add(current.Num);

            //keep going down next left node and add to list if not exist
            if (current.Left != null && !PreorderList.Contains(current.Left.Num))
            {
                PreorderList.Add(current.Left.Num);
                Preorder(current.Left);
            }

            //otherwise go down right side and add to list if not exist
            //the recursive call will still keep checking for left sides
            else
            {
                if (current.Right != null && !PreorderList.Contains(current.Right.Num))
                {
                    PreorderList.Add(current.Right.Num);
                    Preorder(current.Right);
                }
                else
                {
                    //if already exist, then keep moving up
                    Preorder(current.Parent);
                }
            }
        }

        public static void Print(List<int> list)
        {
            var x = "";
            list.ForEach(e => x = x + e + ",");
            Console.WriteLine(x.Substring(0, x.Length-1));
        }

        public static void PrintNode(List<BinaryNode> list)
        {
            foreach (var i in list)
            {
                Console.Write(i.Num + " ");
            }
        }
        public static BinaryTree SetSampleData()
        {
            var l7R = BinaryNode.Fac(7);
            var tree = new BinaryTree(l7R);

            var l1 = tree.Insert(l7R, 1);
            tree.Insert(l1, 0);
            var l3 = tree.Insert(l1, 3);
            tree.Insert(l3, 2);
            var l5 = tree.Insert(l3, 5);
            tree.Insert(l5, 4);
            tree.Insert(l5, 6);

            var l9 = tree.Insert(l7R, 9);
            tree.Insert(l9, 8);
            tree.Insert(l9, 10);

            return tree;
        }
        public static BinaryTree SetSampleData1()
        {
            var l50R = BinaryNode.Fac(7);
            var tree = new BinaryTree(l50R);

            var l25 = tree.Insert(l50R, 25);
            var l75 = tree.Insert(l50R, 75);

            //left
            var l15 = tree.Insert(l25, 15);
            var l35 = tree.Insert(l25, 35);

            var l20 = tree.Insert(l15, 20, true);

            var l30 = tree.Insert(l35, 30);
            var l40 = tree.Insert(l35, 40);

            //right
            var l60 = tree.Insert(l75, 60);
            var l90 = tree.Insert(l75, 90);

            tree.Insert(l60, 65, true);
            tree.Insert(l90, 80);

            return tree;
        }

        public static BinaryTree SetSampleData2()
        {
            var l10 = BinaryNode.Fac(10);
            var tree = new BinaryTree(l10);

            //left
            var l12 = tree.Insert(l10, 12);
            var l5 = tree.Insert(l10, 5);

            tree.Insert(l12, 3);

            var l4 = tree.Insert(l12, 4);

            tree.Insert(l5, 11);
            var l2 = tree.Insert(l5, 2);

            tree.Insert(l4, 6);
            tree.Insert(l4, 7);

            //right
            tree.Insert(l2, 8, true);

            //reference: http://cs-people.bu.edu/tvashwin/cs112_spring09/lab06.html
            //Inorder: 3.12.6.4.7.10.11.5.2.8
            return tree;
        }

        public static BinaryTree SetSampleData3()
        {
            var l9 = BinaryNode.Fac(9);
            var t = new BinaryTree(l9);

            var l12 = t.Insert(l9, 12);
            var l6 = t.Insert(l9, 6);


            var l13 = t.Insert(l12, 13);
            var l25 = t.Insert(l12, 25);

            t.Insert(l6, 4);
            t.Insert(l6, 15);

            t.Insert(l13, 7);
            t.Insert(l13, 1);

            t.Insert(l25, 3);
            t.Insert(l25, 19);

            

            return t;

            //inorder: 7,13,1,12,3,25,19,9,4,6,15
        }
    }
    public class BinaryNode
    {
        public int Num;
        public BinaryNode Parent;
        public BinaryNode Left;
        public BinaryNode Right;
        public static BinaryNode Fac(int num)
        {
            var n = new BinaryNode();
            n.Num = num;
            return n;
        }
    }
}
