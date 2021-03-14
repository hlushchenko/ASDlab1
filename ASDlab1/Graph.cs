using System;

namespace ASDlab1
{
    public class Graph
    {
        private int[,] _weightMatrix;
        private int _size;
        private static int randomMax = 100;

        public Graph(int[,] weightMatrix)
        {
            _weightMatrix = weightMatrix;
            _size = _weightMatrix.GetLength(0);
        }

        public Graph(int size, (int, int, int)[] edges)
        {
            _weightMatrix = new int[size, size];
            _size = size;
            foreach (var edge in edges)
            {
                _weightMatrix[edge.Item1, edge.Item2] = edge.Item3;
                _weightMatrix[edge.Item2, edge.Item1] = edge.Item3;
            }
        }

        public Graph(int size)
        {
            _size = size;
            _weightMatrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    int current = random.Next(randomMax);
                    _weightMatrix[i, j] = current;
                    _weightMatrix[j, 1] = current;
                } 
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write("{0:D5}", _weightMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}