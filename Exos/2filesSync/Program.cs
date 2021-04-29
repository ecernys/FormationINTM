using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2filesSync
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            using (StreamReader sr1 = new StreamReader(path + @"\1.txt"))
            using (StreamReader sr2 = new StreamReader(path + @"\2.txt"))
            {
                int value1 = int.MaxValue;
                int value2 = int.MaxValue;
                bool notEOF1 = true;
                bool notEOF2 = true;

                if (sr1.EndOfStream && sr2.EndOfStream)
                    Console.WriteLine("File 1 and File 2 are empty");
                else
                {
                    if (!sr1.EndOfStream)
                        value1 = int.Parse(sr1.ReadLine());
                    if (!sr2.EndOfStream)
                        value2 = int.Parse(sr2.ReadLine());

                    while (notEOF2 || notEOF1)
                    {
                        // value from file 1 has priority if equal
                        while (notEOF1 && value1 <= value2)
                        {
                            if (value1 != int.MaxValue)
                                Console.WriteLine($"value from file 1 : {value1}");
                            if (sr1.EndOfStream)
                            {
                                notEOF1 = false;
                                value1 = int.MaxValue;
                            }
                            else
                                value1 = int.Parse(sr1.ReadLine());

                        }
                        if (value2 != int.MaxValue)
                            Console.WriteLine($"value from file 2 : {value2}");
                        if (sr2.EndOfStream)
                        {
                            notEOF2 = false;
                            value2 = int.MaxValue;
                        }
                        else
                            value2 = int.Parse(sr2.ReadLine());
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
