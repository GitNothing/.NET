/**
 * Sample of tree tranversal methods
 */

using System;
using System.Collections.Generic;

namespace IV
{
    public class BinaryTree
    {
        public BinaryNode root;

        //You must first run the repective method to generate these list
        public List<int> PreorderList { get; set; } = new List<int>();
        public List<int> PostorderList { get; set; } = new List<int>();
        public List<int> InOrderList { get; set; } = new List<int>();
        public BinaryNode Insert(BinaryNode root, int num, bool isRight = false)
        {
            var n = BinaryNode.Fac(num);
            n.parent = root;
            if (isRight)
            {
                root.right = n;
                return n;
            }
            if (root.left == null)
            {
                //Console.WriteLine(n.num);
                root.left = n;
            }
            else
            {
                //Console.WriteLine(n.num);
                root.right = n;
            }
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
                    return Tran(parent.left, isLeft, t);
                }
                else
                {
                    return Tran(parent.right, isLeft, t);
                }
            }
            return parent;
        }

        public void InOrder(BinaryNode current)
        {
            if (current == null) return;

            //keep moving down left;
            if (current.left != null)
            {
                //left is already tracked
                if (InOrderList.Contains(current.left.num))
                {
                    //move to parent if this node is already tracked
                    if (InOrderList.Contains(current.num))
                    {
                        InOrder(current.parent);
                        return;
                    }

                    //track current node and move right, since all left node is already tracked
//                    Console.WriteLine($"Add current {current.num}");
                    InOrderList.Add(current.num);
                    InOrder(current.right);
                }
                else
                {
                    InOrder(current.left);
                }
            }

            //can't move down left anymore
            else
            {
                //track current, because can't move down anymore
                if (!InOrderList.Contains(current.num))
                {
//                    Console.WriteLine($"Add left {current.num}");
                    InOrderList.Add(current.num);
                }
                else
                {
                    InOrder(current.parent);
                    return;
                }
                
                //if there is a right and it is not track, move to it
                if (current.right != null && !InOrderList.Contains(current.right.num))
                {
                    InOrder(current.right);
                }
                else
                {
                    InOrder(current.parent);
                }
            }
        }

        public void Postorder(BinaryNode current, bool isRightUp = false)
        {
            if (current == null) return;

            //condition to go up on the right nodes
            if (isRightUp)
            {
                if (current.parent != null) //condition not at root
                {
                    //indicates the end since you cannot come back here more than twice
                    if (PostorderList.Contains(current.num))
                    {
                        Postorder(null);
                        return;
                    }
//                    Console.WriteLine($"insert from right {current.num}");
                    PostorderList.Add(current.num);
                    Postorder(current.parent, true);
                }
                else //condition at root
                {
                    Postorder(current.right);
                }
                return;
            }
            if (current.left != null)
            {
                Postorder(current.left);
            }
            else
            {
                if (!PostorderList.Contains(current.num))
                {
//                    Console.WriteLine($"insert left {current.num}");
                    PostorderList.Add(current.num);

                    //go back up to parent and down the next right node
                    Postorder(current.parent.right);
                }
                else
                {
                    //go back up to all the right nodes
                    Postorder(current.parent, true);
                }
            }
        }

        public void Preorder(BinaryNode current)
        {
            if (current == null) return;

            //add node immediately if doesn't exist
            if (!PreorderList.Contains(current.num)) PreorderList.Add(current.num);

            //keep going down next left node and add to list if not exist
            if (current.left != null && !PreorderList.Contains(current.left.num))
            {
                PreorderList.Add(current.left.num);
                Preorder(current.left);
            }

            //otherwise go down right side and add to list if not exist
            //the recursive call will still keep checking for left sides
            else
            {
                if (current.right != null && !PreorderList.Contains(current.right.num))
                {
                    PreorderList.Add(current.right.num);
                    Preorder(current.right);
                }
                else
                {
                    //if already exist, then keep moving up
                    Preorder(current.parent);
                }
            }
        }

        public static void Print(List<int> list)
        {
            var x = "";
            list.ForEach(e => x = x + e + ",");
            Console.WriteLine(x.Substring(0, x.Length-1));
        }
        public static BinaryTree setSampleData()
        {
            var tree = new BinaryTree();
            var l7_r = BinaryNode.Fac(7);
            tree.root = l7_r;
            var l1 = tree.Insert(l7_r, 1);
            tree.Insert(l1, 0);
            var l3 = tree.Insert(l1, 3);
            tree.Insert(l3, 2);
            var l5 = tree.Insert(l3, 5);
            tree.Insert(l5, 4);
            tree.Insert(l5, 6);

            var l9 = tree.Insert(l7_r, 9);
            tree.Insert(l9, 8);
            tree.Insert(l9, 10);

            return tree;
        }
        public static BinaryTree setSampleData1()
        {
            var tree = new BinaryTree();
            var l50_r = BinaryNode.Fac(7);
            tree.root = l50_r;

            var l25 = tree.Insert(l50_r, 25);
            var l75 = tree.Insert(l50_r, 75);

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

        public static BinaryTree setSampleData2()
        {
            var tree = new BinaryTree();
            var l10 = BinaryNode.Fac(10);
            tree.root = l10;

            //left
            var l12 = tree.Insert(l10, 12);
            tree.Insert(l12, 3);

            var l4 = tree.Insert(l12, 4);
            tree.Insert(l4, 6);
            tree.Insert(l4, 7);

            //right
            var l5 = tree.Insert(l10, 5);
            tree.Insert(l5, 11);
            var l2 = tree.Insert(l5, 2);
            tree.Insert(l2, 8, true);

            //reference: http://cs-people.bu.edu/tvashwin/cs112_spring09/lab06.html
            //Inorder: 3.12.6.4.7.10.11.5.2.8
            return tree;
        }
    }
    public class BinaryNode
    {
        public int num;
        public BinaryNode parent;
        public BinaryNode left;
        public BinaryNode right;
        public static BinaryNode Fac(int num)
        {
            var n = new BinaryNode();
            n.num = num;
            return n;
        }
    }
}
