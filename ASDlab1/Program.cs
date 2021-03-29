using System;

namespace ASDlab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = Graph.Input();
            Console.WriteLine();
            graph.PrintMatrix();
            Console.WriteLine();
            var result = graph.Boruvka();
            result.PrintMatrix();
        }
    }
}
