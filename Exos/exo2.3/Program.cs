using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo2._3
{
    class Program
    {
        static int[] EratosthenesSieve(int n)
        {
            int[] ints = new int[n];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i + 1;
            }

            for (int i = 2; i < n; i++)
            {
                for (int k = 0; k < ints.Length; k++)
                {
                    if (ints[k] != 0 && (ints[k] != i && ints[k] % i == 0))
                    {
                        ints[k] = 0;
                    }
                    else
                    {
                        n = (int)Math.Sqrt(k);
                    }
                }
            }
            return ints;
        }

        static int[] EratosthenesSieve2(int n)
        {
            int[] numbers = new int[n + 1];
            numbers[0] = int.MinValue;
            numbers[1] = int.MinValue;
            for (int i = 2; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            int limit = (int)Math.Sqrt(n);
            for (int i = 2; i <= limit; i++)
            {
                if (numbers[i] != int.MinValue)
                {
                    for (int j = i; i * j < numbers.Length; j++)
                    {
                        numbers[i * j] = int.MinValue;
                    }
                }
            }

            return numbers;
        }

        static void Main(string[] args)
        {
            int[] ints = EratosthenesSieve2(100);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

        }
    }
}
