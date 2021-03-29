using System;
using System.Collections.Generic;

namespace ASDlab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = Graph.Input();
            Console.WriteLine();
            Console.WriteLine("D0:");
            graph.PrintMatrix();
            Console.WriteLine();
            var newGraph = graph.FloydWarshall();
            Console.WriteLine("Dn:");
            newGraph.PrintMatrix();
            var paths = newGraph.PathReconstruction(graph);
            Console.WriteLine("\nP(i,j):");
            Graph.PrintMatrix(paths);
        }
    }
}