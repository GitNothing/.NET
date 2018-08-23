using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    public class Network
    {
        public Dictionary<char, Node> Nodes { get; set; } = new Dictionary<char, Node>();
        public Node Root { get; set; }
        public Network(Node root)
        {
            Root = root;
        }
        public Node Insert(Node root, char Sym, int weight = 1)
        {
            var n = new Node();
            n.Sym = Sym;
            n.Links.Add(root.Sym, root);
            n.SetWeight(root, n, weight);
            root.Links.Add(Sym, n);

            Nodes.Add(Sym, n);
            return n;
        }

        public void Link(Node root, Node appender, int weight = 1)
        {
            root.Links.Add(appender.Sym, appender);
            appender.Links.Add(root.Sym, root);
            root.SetWeight(root, appender, weight);
        }
    }

    public class Node
    {
        public bool hasVisited { get; set; }
        public char Sym { get; set; }
        public Dictionary<char, Node> Links { get; set; } = new Dictionary<char, Node>();
        public Dictionary<char, NodeWeight> WeightPairs { get; set; } = new Dictionary<char, NodeWeight>(); //char is the Value of N1

        public void SetWeight(Node N1, Node N2, int Weight)
        {
            var w = new NodeWeight();
            w.N1 = N1;
            w.N2 = N2;
            w.Weight = Weight;
            WeightPairs.Add(N1.Sym, w);
        }
    }

    public class NodeQuad<type>
    {
        public bool hasVisited { get; set; }
        public type Value { get; set; }
        public Dictionary<type, NodeQuad<type>> Links { get; set; } = new Dictionary<type, NodeQuad<type>>();
        private NodeQuad<type>[] attached = {null, null, null, null};
        public enum Side
        {
            Top,
            Right,
            Bottom,
            Left
        };

        public NodeQuad(type value)
        {
            Value = value;  
        }
        public NodeQuad<type> Get(Side side)
        {
            switch (side)
            {
                case Side.Top:
                    return attached[0];
                case Side.Right:
                    return attached[1];
                case Side.Bottom:
                    return attached[2];
                case Side.Left:
                    return attached[3];
            }
            return null;
        }
        public void Set(NodeQuad<type> node, Side side)
        {
            Links.Add(node.Value, node);
            switch (side)
            {
                case Side.Top:
                    attached[0] = node;
                    break;
                case Side.Right:
                    attached[1] = node;
                    break;
                case Side.Bottom:
                    attached[2] = node;
                    break;
                case Side.Left:
                    attached[3] = node;
                    break;
            }
        }
        public void Remove(NodeQuad<type> node)
        {
            var hash = node.GetHashCode();
            Links.Remove(node.Value);
            for (int i = 0; i < attached.Length; i++)
            {
                if (attached[i] == null) continue;
                if (attached[i].GetHashCode() == hash)
                {
                    attached[i] = null;
                    return;
                }
            }
        }
    }

    public class NodeWeight
    {
        public Node N1 { get; set; }
        public Node N2 { get; set; }
        public int Weight { get; set; }
    }
}
