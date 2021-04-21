using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo2._2
{
    class Program
    {
        static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[][] matrix = new int[leftVector.Length][];
            for (int i = 0; i < leftVector.Length; i++)
            {
                matrix[i] = new int[rightVector.Length];
                for (int j = 0; j < rightVector.Length; j++)
                {
                    matrix[i][j] = leftVector[i] * rightVector[j];
                }
            }
            return matrix;
        }

        static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] matrix = new int[leftMatrix.Length][];
            for (int i = 0; i < leftMatrix.Length; i++)
            {
                matrix[i] = new int[leftMatrix[i].Length];
                for (int j = 0; j < leftMatrix[i].Length; j++)
                {
                    matrix[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                }
            }
            return matrix;
        }        
        static int[][] Substraction(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] matrix = new int[leftMatrix.Length][];
            for (int i = 0; i < leftMatrix.Length; i++)
            {
                matrix[i] = new int[leftMatrix[i].Length];
                for (int j = 0; j < leftMatrix[i].Length; j++)
                {
                    matrix[i][j] = leftMatrix[i][j] - rightMatrix[i][j];
                }
            }
            return matrix;
        }        
        static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {
            int lRows = leftMatrix.Length;
            int rCols = rightMatrix[0].Length;
            int lCols = leftMatrix[0].Length;
            
            int[][] matrix = new int[lRows][];
            for (int i = 0; i < lRows; i++)
            {
                matrix[i] = new int[rCols];
                for (int j = 0; j < rCols; j++)
                {
                    for (int k = 0; k < lCols; k++)
                    {
                        matrix[i][j] += leftMatrix[i][k] * rightMatrix[k][j];
                    }
                }
            }
            return matrix;
        }
        static void printMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                //Console.WriteLine($"Ligne {i}");
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[] ints1 = { 1, 2, 3 };
            int[] ints2 = { 10, 20, 30 };
            int[][] matrix = BuildingMatrix(ints1, ints2);
            Console.WriteLine("generation de matrix1");
            printMatrix(matrix);
            
            int[] ints3 = { -1, -2, -3 };
            int[] ints4 = { 10, 20, 30 };
            int[][] matrix2 = BuildingMatrix(ints3, ints4);

            int[][] left = new int [][]
            {
                new int [] {1, 2},
                new int [] {4, 6},
                new int [] {-1, 8},
            };

            int[][] right = new int [][]
            {
                new int [] {-1, 5, 0},
                new int [] {-4, 0, 1},
            };

            Console.WriteLine("generation de matrix2");
            printMatrix(matrix2);

            Console.WriteLine("Addition");
            int[][] matrix3 = Addition(matrix, matrix2);
            printMatrix(matrix3);
            Console.WriteLine("Substraction matrix2 de matrix1 ");
            int[][] matrix4 = Substraction(matrix, matrix2);
            printMatrix(matrix4);
            Console.WriteLine("Multiplication");
            int[][] matrix5 = Multiplication(left, right);
            printMatrix(matrix5);



            Console.ReadKey();
        }
    }
}
