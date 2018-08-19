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
        public Dictionary<char, NodeWeight> WeightPairs { get; set; } = new Dictionary<char, NodeWeight>(); //char is the value of N1

        public void SetWeight(Node N1, Node N2, int Weight)
        {
            var w = new NodeWeight();
            w.N1 = N1;
            w.N2 = N2;
            w.Weight = Weight;
            WeightPairs.Add(N1.Sym, w);
        }
    }

    public class NodeWeight
    {
        public Node N1 { get; set; }
        public Node N2 { get; set; }
        public int Weight { get; set; }
    }
}
