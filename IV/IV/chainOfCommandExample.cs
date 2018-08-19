using System;

namespace IV
{
    public class ChainOfCommandExample
    {
        public ChainOfCommandExample()
        {
            var root = new Handler(0);
            var h1 = new Handler(1);
            var h2 = new Handler(2);
            root.SetNext(h1);
            h1.SetNext(h2);

            root.Execute();
        }
        //A class that only purpose is to hand over execution to the next of its kind after execution
        class Handler
        {
            private readonly int _id;
            private Handler _nextInChain;
            public Handler(int id)
            {
                _id = id;
            }

            public void SetNext(Handler next)
            {
                _nextInChain = next;
            }

            public void Execute()
            {
                Console.WriteLine("Chain executed on ID " + _id);

                //put some execution condition in here
                _nextInChain?.Execute();
            }
        }
    }
}
