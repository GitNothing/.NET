using System;

namespace IV
{
    class VisitorExample
    {
        public VisitorExample()
        {
            var host = new X();
            var host1 = new Y();
            var B = new B();
            var A = new A();

            //host is like a utility that will process according to visitor A and B
            B.Visit(host);
            A.Visit(host);

            B.Visit(host1);
            A.Visit(host1);
        }

        #region required interface for this pattern
        interface IVisitor
        {
            void Visit(IVisitable host);
        }
        interface IVisitable
        {
            void accept(A visitor);
            void accept(B visitor);
        }
        #endregion

        #region Visitors
        class A : IVisitor
        {
            public void Visit(IVisitable unit)
            {
                unit.accept(this);
            }
        }
        class B : IVisitor
        {
            public void Visit(IVisitable unit)
            {
                unit.accept(this);
            }
        }
        #endregion

        #region host that are visitable
        //process any visit from class A and B
        class X : IVisitable
        {
            public void accept(A unit)
            {
                Console.WriteLine("Process A from X");
            }

            public void accept(B unit)
            {
                Console.WriteLine("Process B from X");
            }
        }

        class Y : IVisitable
        {
            public void accept(A unit)
            {
                Console.WriteLine("Process A from Y");
            }

            public void accept(B unit)
            {
                Console.WriteLine("Process B from Y");
            }
        }
        #endregion
    }
}
