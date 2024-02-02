using System;
using System.Collections.Generic;
using FindShortestPathUsingDijkstrasAlgorithm.Models;

namespace FindShortestPathUsingDijkstrasAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            FindShortestPath shortestPath = new FindShortestPath();

            int[,] graph = new int[,] { { 0, 4, 6, 0, 0, 0, 0, 0, 0 },
                                    { 4, 0, 0, 0, 0, 2, 0, 0, 0 },
                                    { 6, 0, 0, 8, 0, 0, 0, 0, 0 },
                                    { 0, 0, 8, 0, 4, 0, 1, 0, 0 },
                                    { 0, 2, 0, 4, 0, 3, 0, 0, 8 },
                                    { 0, 2, 0, 0, 3, 0, 4, 6, 0 },
                                    { 0, 0, 0, 1, 0, 4, 0, 5, 5 },
                                    { 0, 0, 0, 0, 0, 6, 5, 0, 0 },
                                    { 0, 0, 0, 0, 8, 0, 5, 0, 0 } };

            ShortestPathData shortestPathData = shortestPath.GetShortestPath(graph, "A", "G");

            Console.WriteLine("Node List: " + string.Join(", ", shortestPathData.NodeNames));
            Console.WriteLine("Total Distance: " + shortestPathData.Distance);
        }
    }
}
