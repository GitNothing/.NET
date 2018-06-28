using System;
using System.Linq;

namespace IV
{
    public class LinqTest
    {
        public LinqTest()
        {
            var ic = new TestModel[5];
            ic[0] = new TestModel("test1", 43);
            ic[1] = new TestModel("test5", 4);
            ic[2] = new TestModel("test1", 1);
            ic[3] = new TestModel("test4", 1);
            ic[4] = new TestModel("test5", 9);

            var ib = new TestModel[5];
            ib[0] = new TestModel("cat1", 1);
            ib[1] = new TestModel("cat2", 2);
            ib[2] = new TestModel("test1", 3);
            ib[3] = new TestModel("cat4", 4);
            ib[4] = new TestModel("cat5", 5);

            var i = new int[] { 3, 4, 5, 2, 3, 4, 53, 8, 4, 3 };
            var k = from ia in ic orderby ia.name select ia.value2;
            var k1 = from a in ic join b in ib on new { comp = a.name } equals new { comp = b.name } select a;
            var k2 = from a in ic group a by a.value > 3;
            var k3 = i.Where(a => a > 3).Where(b => b > 8);
            var k4 = ic.OrderBy(a => a.name).OrderBy(a => a.value);
            var k5 = ic.Select(p => new { Last = p.name });
            var k55 = ib.Where(x => x.name == "test1").Select(s => new { s.name, s.value });
            var k6 = ic.SelectMany(e => ib.Where(x => x.name == e.name).Select(s => new { s.name, e.value }));
            var k7 = ic.Concat(ib).OrderBy(x => x.name);
            var k8 = i.Distinct();
            foreach (var i1 in k2)
            {
                Console.WriteLine($"number {i1.Key}");
                foreach (var i2 in i1)
                {
                    Console.WriteLine($"g {i2.name}");
                }
            }
        }
        class TestModel
        {
            public string name;
            public int value;
            public int value2;
            public TestModel(string n, int v)
            {
                name = n;
                value = v;
                var r = new Random();
                value2 = r.Next(2, 20);
            }

            public static bool gt5(int i)
            {
                if (i > 5) return true;
                return false;
            }
        }
    }

}
