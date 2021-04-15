using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo5
{
    class Program
    {
        static bool IsPrime(int value)
        {
            if (value > 0)
            {
                double sqrt = Math.Sqrt(value);
                int n = (int)Math.Floor(sqrt) + 1;

                for (int i = 2; i < n; i++)
                {
                    if (value % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        static void DisplayPrimes()
        {
            for (int i = 1; i < 101; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            DisplayPrimes();
            Console.ReadKey();
        }
    }
}
