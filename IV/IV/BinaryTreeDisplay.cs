using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    class BinaryTreeDisplay
    {
        private readonly BinaryTree tree;
        public List<LNode> LNodes { get; set; } = new List<LNode>();
        public int MaxDepth { get; set; }
        public BinaryTreeDisplay()
        {
            var t = BinaryTree.SetSampleData2();
            PreorderMarker(t.Root, 0);

        }

        private void TreeBuilder()
        {

        }
        private void PreorderMarker(BinaryNode current, int depth)
        {
            if (current == null) return;

            //condition to track current
            if (needTrack(current))
            {
                Console.WriteLine($"adding {current.Num} at depth of {depth}");
                if (depth < MaxDepth) depth = MaxDepth;
                LNodes.Add(LNode.Fac(current, depth));

                if (needTrack(current.Left))
                {
                    PreorderMarker(current.Left, depth + 1);
                }
                else if(needTrack(current.Right))
                {
                    PreorderMarker(current.Right, depth + 1);
                }
                else
                {
                    PreorderMarker(current.Parent, depth - 1);
                }
            }
            else
            {
                if (needTrack(current.Right))
                {
                    PreorderMarker(current.Right, depth + 1);
                }
                else
                {
                    PreorderMarker(current.Parent, depth - 1);
                }
            }
        }

        private bool needTrack(BinaryNode node)
        {
            if (node == null) return false;
            var tracking = LNodes.FindAll(e => e.Node.Num == node.Num);
            return !tracking.Any();
        }
    }

    class LNode
    {
        public BinaryNode Node { get; set; }
        public int Level { get; set; }
        public static LNode Fac(BinaryNode node, int level)
        {
            var n = new LNode();
            n.Node = node;
            n.Level = level;
            return n;
        }
    }
}
