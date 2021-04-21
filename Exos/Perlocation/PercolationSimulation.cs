using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }

        public string toString()
        {
            return $"Mean : {Mean}, Standard deviation : {StandardDeviation}, Relative std : {RelativeStd}";
        }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            double[] values = new double[t];
            for (int i = 0; i < t; i++)
            {
                values[i] = PercolationValue(size);
            }
            double Mean = values.Sum() / values.Length;

            double Std = 0;
            for (int i = 0; i < t; i++)
            {
                Std += (values[i] - Mean) * (values[i] - Mean);
            }
            Std = Math.Sqrt(Std / t);

            return new PclData
            {
                Mean = Mean,
                StandardDeviation = Std,
                RelativeStd = Std / Mean  
            };
        }

        public double PercolationValue(int size)
        {
            double open = 0;
            double total = size * size;
            Percolation percolation = new Percolation(size);
            Random random = new Random();

            while (!percolation.Percolate())
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                if (!percolation.IsOpen(x, y))
                {
                    open++;
                    percolation.Open(x, y);
                }
            }
            return open / total;
        }
    }
}
