using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo3
{
    class Program
    {

        static string prepare(int n, char c)
        {
            string reponse = String.Empty;
            if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    reponse += c;
                }
                return reponse;
            }
            else
            {
                return "";
            }
        }
        static void PyramidConstruction(int n, bool isSmooth)
        {
            if (isSmooth)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"{prepare(n - i - 1, ' ')}{prepare(i * 2 + 1, '+')}");
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(
                        i % 2 == 0 ? $"{prepare(n - i - 1, ' ')}{prepare(i * 2 + 1, '+')}" 
                                   : $"{prepare(n - i - 1, ' ')}{prepare(i * 2 + 1, '-')}"
                    );
                }
            }

        }
        static void Main(string[] args)
        {
            PyramidConstruction(10, true);
            PyramidConstruction(10, false);
            PyramidConstruction(1, true);
            PyramidConstruction(1, false);
            Console.ReadKey();
        }
    }
}
