using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_Delegate_Ass2
{
    class Program
    {
        static void Main(string[] args)
        {
            IntList list = new IntList();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            list.Add(99);

            list.Act(Console.WriteLine);

            list.Filter(delegate (int x) { return x % 2 == 0; }).Act(Console.WriteLine);
            list.Filter(delegate (int y) { return y >= 25; }).Act(Console.WriteLine);

            var sum = 0;
            //list.Filter(delegate (int i) { sum += i; return true; });
            list.Filter(delegate (int i) { bool check = i % 2 == 0; if (check) { sum += i; }; return check; });
            Console.WriteLine(sum);

            while (true) ;
        }
    }
}
