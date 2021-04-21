using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformance
{
    class Program
    {
        const int MIN_VALUE = -1000;
        const int MAX_VALUE = 1000;
        static long UseInsertionSort(int[] array)
        {
            Stopwatch s = Stopwatch.StartNew();
            InsertionSort(array);
            s.Stop();
            return s.ElapsedMilliseconds;
        }
        static long UseQuickSort(int[] array)
        {
            Stopwatch s = Stopwatch.StartNew();
            QuickSort(array, 0, array.Length - 1);
            s.Stop();
            return s.ElapsedMilliseconds;
        }
        static List<int[]> ArraysGenerator(int size)
        {
            List<int[]> tables = new List<int[]>();
            Random randNum = new Random();
            if (size > 0)
            {
                int[] table = Enumerable
                              .Repeat(1, size)
                              .Select(i => randNum.Next(MIN_VALUE, MAX_VALUE))
                              .ToArray();
                tables.Add(table);
                tables.Add(table);
            }
            return tables;
        }
        static SortData PerformanceTest(int size, int count)
        {
            SortData data = new SortData();
            List<int[]> arrays = ArraysGenerator(size);
            for (int i = 0; i < count; i++)
            {
                data.InsertionMean += UseInsertionSort(arrays[0]);
            }
            data.InsertionMean /= count;

            for (int i = 0; i < count; i++)
            {
                data.InsertionStd += UseInsertionSort(arrays[0]) ^ 2;
            }
            double.TryParse((data.InsertionStd / 4), out (long)data.InsertionStd);
            data.InsertionStd = Math.Sqrt();

        }
        static List<SortData> PerformancesTest(List<int> sizes, int count)
        {

        }

        static void Main(string[] args)
        {
            var list = ArraysGenerator(10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list[0][i]);
            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }




        static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
            };
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            int tmp = array[i];
            array[i] = array[right];
            array[right] = tmp;
            return i;
        }
    }
}
