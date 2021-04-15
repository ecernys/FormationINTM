using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4
{
    class Program
    {
        static int Factorial(int n)
        {
            int reponse = 1;
            for (int i = 1; i < n+1; i++)
            {
                reponse *= i;
            }
            return reponse;
        }
        static int FactorialRecursif(int n)
        {
            //int reponse = n;
            //if(n == 0)
            //{
            //    reponse = 1;
            //}
            if (n > 1)
            {
                return n * FactorialRecursif(n - 1);
            }
            return 1;
        } 
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(0));
            Console.WriteLine(Factorial(1));
            Console.WriteLine(Factorial(2));
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Factorial(4));
            Console.WriteLine(Factorial(5));
            //Console.WriteLine(FactorialRecursif(0));
            //Console.WriteLine(FactorialRecursif(1));
            Console.WriteLine(FactorialRecursif(2));
            Console.WriteLine(FactorialRecursif(3));
            Console.WriteLine(FactorialRecursif(4));
            Console.WriteLine(FactorialRecursif(5));
            Console.ReadKey();
        }
    }
}
