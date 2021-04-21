using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo2._1
{
    class Program
    {

        static int LinearSearch(int[] tableau, int valeur)
        {
            int reponse = -1;
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    return i;
                }
            }
            return reponse;
        }

        static int BinarySearch(int[] tableau, int valeur)
        {
            Array.Sort(tableau);
            int min = 0;
            int max = tableau.Length - 1;
            int centre = (max - min) / 2;
            if (tableau[0] == valeur)
            {
                return 0;
            }
            if (tableau[tableau.Length -1] == valeur)
            {
                return tableau.Length - 1;
            }
            
            do
            {
                if (tableau[centre] == valeur)
                {
                    return centre;
                }
                else if (tableau[centre] > valeur)
                {
                    max = centre;
                    centre = (max - min) / 2;
                }
                else
                {
                    min = centre;
                    centre = min + (max - min) / 2;
                }
            } while (centre != 0);
            return -1;
        }
        static void Main(string[] args)
        {
            int[] ints = { 1, -2, 3, 184, 5, 96, 7, 8, 9, 100 };
            int[] empty = { };
            int[] empty2 = new int[5];
            //int[] empty3 = null;
            //Console.WriteLine(LinearSearch(ints, 0));
            //Console.WriteLine(LinearSearch(empty, 0));
            //Console.WriteLine(LinearSearch(empty2, 0));
            //Console.WriteLine(LinearSearch(ints, 5));
            //Console.WriteLine(BinarySearch(ints, 0));
            //Console.WriteLine(BinarySearch(empty, 0));
            //Console.WriteLine(BinarySearch(empty2, 0));
            Console.WriteLine(BinarySearch(ints, 5));
            Console.WriteLine(BinarySearch(ints, 1));
            Console.WriteLine(BinarySearch(ints, 7));
            Console.WriteLine(BinarySearch(ints, 10));
            Console.WriteLine(BinarySearch(ints, 4));
            Console.WriteLine(BinarySearch(ints, -9));
            Console.ReadKey();
        }
    }
}
