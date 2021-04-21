using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            PercolationSimulation p = new PercolationSimulation();
            Console.WriteLine(p.MeanPercolationValue(100, 1000).toString());

            Console.ReadKey();
        }
    }
}
