using System;
using System.Collections.Generic;

namespace ASDlab1
{
    public class Graph
    {
        public int[,] WeightMatrix;
        private int _size;
        private static int randomMax = 120;

        public Graph(int[,] weightMatrix)
        {
            WeightMatrix = weightMatrix;
            _size = WeightMatrix.GetLength(0);
        }

        public Graph(int size)
        {
            _size = size;
            WeightMatrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int current = random.Next(randomMax) + 1;
                    if (i == j)
                    {
                        WeightMatrix[i, j] = 0;
                    }
                    else if (current > 99)
                    {
                        WeightMatrix[i, j] = Int32.MaxValue / 2;
                    }
                    else
                    {
                        WeightMatrix[i, j] = current;
                    }
                }
            }
        }

        public int[,] PathReconstruction(Graph originGraph)
        {
            
            int[,] output = new int[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        int a = WeightMatrix[i, j];
                        int b = WeightMatrix[i, k];
                        int c = originGraph.WeightMatrix[k, j];
                        if (a == b + c && j != k && originGraph.WeightMatrix[i, j] != Int32.MaxValue/2 && originGraph.WeightMatrix[i, j]!=0 )
                        {
                            output[i, j] = k+1;
                        }
                    }
                }
            }

            return output;
        }
        
        public Graph FloydWarshall()
        {
            int[,] newWeightMatrix = WeightMatrix;
            for (int m = 0; m < _size; m++)
            {
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        if (newWeightMatrix[i, j] > newWeightMatrix[i, m] + newWeightMatrix[m, j])
                        {
                            newWeightMatrix[i, j] = newWeightMatrix[i, m] + newWeightMatrix[m, j];
                        }
                    }
                }
            }

            return new Graph(newWeightMatrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            new Graph(matrix).PrintMatrix();
        }


        public void PrintMatrix()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (WeightMatrix[i, j] >= Int32.MaxValue / 2)
                    {
                        Console.Write("inf  ");
                    }
                    else
                    {
                        Console.Write("{0:D2}   ", WeightMatrix[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }

        public static Graph Input()
        {
            Console.WriteLine("input matrix size:");
            int size = Int32.Parse(Console.ReadLine() ?? string.Empty);
            int[,] matrix = new int[size, size];
            Console.WriteLine("input matrix (ENTER for random):");

            for (int i = 0; i < size; i++)
            {
                string[] current = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (current.Length == 0)
                {
                    return new Graph(size);
                }

                for (int j = 0; j < size; j++)
                {
                    if (current[j].ToLower() == "inf")
                    {
                        matrix[i, j] = Int32.MaxValue / 2;
                    }
                    else
                        matrix[i, j] = Int32.Parse(current[j]);
                }
            }

            return new Graph(matrix);
        }
    }
}