using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo6
{
    class Program
    {
        static int Gcd(int a, int b)
        {
            int sup = a;
            int inf = b;

            if (b > a)
            {
                sup = b;
                inf = a;
            }
            
            if (inf != 0 && sup % inf != 0)
            {
                sup = inf;
                inf = sup / inf;
                return Gcd(sup, inf);
            }
            else
            {
                return inf;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Gcd(100, 50));
            Console.WriteLine(Gcd(50, 100));
            Console.WriteLine(Gcd(3, 7));
            Console.WriteLine(Gcd(1, 5));
            Console.WriteLine(Gcd(1000, 13));
            Console.ReadKey();
        }
    }
}
