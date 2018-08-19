using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.youtube.com/watch?v=QRq6p9s8NVg

namespace IV
{
    public class BreadthFS
    {
        public static List<Node> Queuer = new List<Node>();
        public static List<Node> Output = new List<Node>();
        public static string result = "";
        public BreadthFS(bool run)
        {
            if (!run) return;
            var n = BreadthFS.SampleData();
            var current = n.Nodes['a'];
            Queuer.Add(current);
            current.hasVisited = true;
            Transverse(current);
            Console.WriteLine(result);
        }

        public virtual void Transverse(Node current)
        {
            if (current == null) return;
            Console.WriteLine($"On node {current.Sym}");
            var hasSome = false;
            foreach (var link in current.Links)
            {
                //Add to queue for checking if it is unvisited
                if (!link.Value.hasVisited)
                {
                    hasSome = true;
                    link.Value.hasVisited = true;
                    Queuer.Add(link.Value);
                    Console.WriteLine("Enq: " + link.Value.Sym);
                }
            }

            //Dequeue since this node no longer have unvisited nodes
            if (!hasSome)
            {
                Console.WriteLine("Deq: " + current.Sym);
                Queuer.Remove(current);
                Output.Add(current);
                result = result + current.Sym.ToString();
            }

            //Check node that is on the queue FIFO
            Transverse(Queuer.FirstOrDefault());
        }

        public static Network SampleData()
        {
            var n = new Node();
            n.Sym = 'b';
            var network = new Network(n);
            var a = network.Insert(n, 'a');
            var s = network.Insert(a, 's');
            var c = network.Insert(s, 'c');
            var g = network.Insert(s, 'g');
            var f = network.Insert(g, 'f');
            var h = network.Insert(g, 'h');
            network.Link(f, c);
            var e = network.Insert(h, 'e');
            network.Link(e, c);
            var d = network.Insert(c, 'd');
            return network;
        }
    }
}
