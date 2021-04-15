using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo1
{
    class Program
    {
        static void basicOperation(int a, int b, char operation)
        {
            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{a} {operation} {b} = {a + b}");
                    break;
                case '/':
                    integerDivision(a, b);
                    break;
                case '*':
                    Console.WriteLine($"{a} {operation} {b} = {a * b}");
                    break;
                case '-':
                    Console.WriteLine($"{a} {operation} {b} = {a - b}");
                    break; 
                case '^':
                    pow(a, b);
                    break;
                default:
                    Console.WriteLine($"{a} {operation} {b} = Opération invalide");
                    break;
            }

        }

        static void integerDivision(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide");
            }
            else
            {
                Console.WriteLine((a % b) == 0 ? $"{a} =  {a / b} * {b}" : $"{a} =  {a / b} * {b} + {a % b}");
            }
        }

        static void pow(int a, int b)
        {
            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = Opération invalide");
            }
            else
            {
                Console.WriteLine($"{a} ^ {b} = {Math.Pow(a, b)}");
            }
            
        }
        static void Main(string[] args)
        {
            basicOperation(2, 3, '+');
            basicOperation(2, 3, '-');
            basicOperation(2, 3, '*');
            basicOperation(2, 3, '/');
            basicOperation(4, 2, '/');
            basicOperation(2, 0, '/');
            basicOperation(2, 6, 'L');
            basicOperation(2, 6, '^');
            basicOperation(2, -6, '^');

            Console.ReadKey();
        }
    }
}
