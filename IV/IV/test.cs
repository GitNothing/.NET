using System;
using System.Linq;
using System.Security.Cryptography;

namespace IV
{
    public class testb
    {
        public string text = "undef";
        public testb(int id)
        {

        }

        public void meth1()
        {
            text = "meth1";
        }
    }
    public class test: testb
    {
        public test(int xyz):base(123)
        {
            
        }

        public test(string abc):this(123)
        {

        }

        public void methx(obj abc)
        {
            abc.objs = "methx";
        }
        public void meths(string abc)
        {
            abc = "meths";

            try
            {
                return;
                Console.WriteLine("try block");
            }
            catch
            {
                Console.WriteLine("catch block");
            }
            finally
            {
                Console.WriteLine("inside finally");
            }
            Console.WriteLine("after thrown");
        }
    }

    public class a
    {
        public a()
        {
            var x = new test(123);
            var o = new obj();
            var s = "original";
            x.methx(o);
            x.meths(s);
            Console.ReadKey();
        }

    }

    public abstract class obja
    {
        public obja()
        {
            
        }

        public abstract void meth();

        public virtual void methv()
        {
            Console.WriteLine("hi");
        }
    }
    public class obj: obja
    {
        public string objs = "some obj1";
        public override void meth()
        {
            throw new NotImplementedException();
        }

        public override void methv()
        {

        }
    }

}
