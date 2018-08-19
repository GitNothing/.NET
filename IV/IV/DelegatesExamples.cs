using System;

namespace IV
{
    class DelegatesExamples
    {
        public delegate void testDel(string input); //cannot be static
        public void attachMethod(string input) { Console.WriteLine(input); } //method that prints hello1

        public DelegatesExamples()
        {
            //normal delegate, define as a member
            testDel del = attachMethod;
            del.Invoke("hello1");

            //anonymous delegate
            testDel aDel = x => Console.WriteLine(x + " from annoy");
            aDel.Invoke("hello2");

            //builtin Action delegate
            Action<string> actDel;
            actDel = x => Console.WriteLine("Action " + x);
            actDel.Invoke("hello3");

            //builtin Func delegate, x="1". Return type is int. Param is a string.
            Func<string, int> funcDel;
            funcDel = x => Int32.Parse(x + x); //auto returns
            var gets = funcDel.Invoke("1");
            Console.WriteLine("Func " + gets);

            //builtin Predicate delegate, can only return bool
            Predicate<string> predDel;
            predDel = x => x == "helloworld";
            var isTrue = predDel.Invoke("helloworld");
        }
    }
}
