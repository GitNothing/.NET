using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV
{
    public class DepthFS: BreadthFS
    {
        public DepthFS():base(false)
        {
            var n = BreadthFS.SampleData();
            var current = n.Nodes['a'];
            Queuer.Add(current);
            current.hasVisited = true;
            Transverse(current);
            Console.WriteLine(result);
        }

        public override void Transverse(Node current)
        {
//            Console.WriteLine($"Current {current.Sym}");
            
            //Get any linked node that is not visited
            var anUnvisited = current.Links.ToList().FindAll(e => e.Value.hasVisited == false);

            //If any, then add one to stack
            if (anUnvisited.Any())
            {
                var node = anUnvisited.FirstOrDefault();
                node.Value.hasVisited = true;
                Console.WriteLine("Push " + node.Value.Sym);
                Queuer.Add(node.Value);
            }
            //If none exist, then pop left from stack
            else
            {
                result = result + current.Sym;
                Console.WriteLine("Pop " + current.Sym);
                Queuer.Remove(current);
            }
            if (!Queuer.Any()) return;
            Transverse(Queuer.Last());
        }
    }
}
