using System;
using System.Collections.Generic;

namespace ASDlab1
{
    public class Graph
    {
        private Queue<int> a;
        public int[,] WeightMatrix;
        private int _size;
        private static int randomMax = 99;
        public int size
        {
            get { return _size + 3; }
        }

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
                    for (int j = i + 1; j < size; j++)
                    {
                        int current = random.Next(randomMax) + 1;
                        WeightMatrix[i, j] = current;
                        WeightMatrix[j, i] = current;
                    
                }
            }
        }
        
        public Graph Boruvka()
        {
            int[,] result = new int[_size,_size];
            List<bool[]> forest = new List<bool[]>();
            int count = 0;
            for (int i = 0; i < _size; i++)
            {
                forest.Add(new bool[_size]);
                        forest[i][i] = true;
            }
            while (count < size)
            {
                for (int k = 0; k < forest.Count; k++)
                {
                    int min = Int32.MaxValue;
                    (int, int) index = (0, 0);
                    for (int i = 0; i < _size; i++)
                    {
                        if (forest[k][i])
                        {
                            for (int j = 0; j < _size; j++)
                            {
                                if (WeightMatrix[i, j] < min && WeightMatrix[i,j]>0 && !forest[k][j])
                                {
                                    min = WeightMatrix[i, j];
                                    index = (i, j);
                                }
                            }
                        }
                    }
                    if (min != Int32.MaxValue)
                    {
                        forest[k][index.Item2] = true;
                        result[index.Item1, index.Item2] = min;
                        result[index.Item2, index.Item1] = min;
                        count++;
                    }
                }
            }
            return new Graph(result);
        }
        
        public void PrintMatrix()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write("{0:D2}   ", WeightMatrix[i, j]);
                }

                Console.WriteLine();
            }
        }
        
        public static Graph Input()
        {
            Console.WriteLine("input matrix size:");
            int size = Int32.Parse(Console.ReadLine() ?? string.Empty);
            int[,] matrix = new int[size,size];
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
                    matrix[i, j] = Int32.Parse(current[j]);
                }
            }
            return new Graph(matrix);
        }

        
    }
}