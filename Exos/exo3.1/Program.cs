using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo3._1
{
    class Program
    {
        static void SchoolMeans(string input, string output)
        {
            Dictionary<string, List<double>> means = new Dictionary<string, List<double>>();
            using (StreamReader sr = new StreamReader(input))
            {
                while (!sr.EndOfStream)
                {
                    string [] data = sr.ReadLine().Split(';');
                    string mean = data[1];
                    string note = data[2].Replace('.', ',');
                    if (means.ContainsKey(mean))
                    {
                        means[mean].Add(double.Parse(note));
                    }
                    else
                    {
                        means.Add(mean, new List<double>() { double.Parse(note) });
                    };
                }
            };

            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (var mean in means)
                {
                    sw.WriteLine($"{mean.Key};{mean.Value.Average().ToString(".0")}");
                }
            };
        }
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string input = path + @"\classe.csv";
            string output = path + @"\notes.csv";

            SchoolMeans(input, output);
            Console.WriteLine("Programme reussi");
            Console.ReadKey();
        }
    }
}
