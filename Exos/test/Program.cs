using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        /// <summary>
        /// Description de la méthode
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DateTime date = DateTime.Now;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Dictionary<int, String> dict = new Dictionary<int, string>() { { 1, "toto" } };

            dict[2] = "new";

            
            Console.ReadKey();
        }
    }
}
