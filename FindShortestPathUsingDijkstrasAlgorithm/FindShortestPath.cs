using System;
using System.Collections.Generic;
using FindShortestPathUsingDijkstrasAlgorithm.Models;

class FindShortestPath
{

	static int V = 9;
	int GetMinDistance(int[] distance,
					bool[] visitedNodes)
	{
		int min = int.MaxValue;
		int minDistanceIndex = -1;

		for (int v = 0; v < V; v++)
			if (visitedNodes[v] == false && distance[v] <= min)
			{
				min = distance[v];
				minDistanceIndex = v;
			}

		return minDistanceIndex;
	}

	public ShortestPathData GetShortestPath(int[,] graphNode, string fromNodeName, string toNodeName)
	{
		int[] distance = new int[V];
		bool[] visitedNodes = new bool[V];

		Dictionary<int, int> previousNodeIndex = new Dictionary<int, int>();
		List<String> nodeNamesCollection = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H", "I"};

		int sourceNode = nodeNamesCollection.IndexOf(fromNodeName);
		int destinationNode = nodeNamesCollection.IndexOf(toNodeName);

		for (int i = 0; i < V; i++)
		{
			distance[i] = int.MaxValue;
			visitedNodes[i] = false;
			previousNodeIndex.Add(i, -1);
		}

		distance[sourceNode] = 0;

		for (int count = 0; count < V - 1; count++)
		{
			int u = GetMinDistance(distance, visitedNodes);

			visitedNodes[u] = true;
			for (int v = 0; v < V; v++)
				if (!visitedNodes[v] && graphNode[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graphNode[u, v] < distance[v])
				{
					distance[v] = distance[u] + graphNode[u, v];
					previousNodeIndex[v] = u;
				}
		}

		int previouslyVisitedNode = previousNodeIndex[destinationNode];
		List<int> shortestPath = new List<int>{};
		shortestPath.Add(destinationNode);

		while (previouslyVisitedNode > 0) {
			shortestPath.Add(previouslyVisitedNode);
			previouslyVisitedNode = previousNodeIndex[previouslyVisitedNode];
		}
		shortestPath.Add(sourceNode);
		shortestPath.Reverse();

		List<string> nodeNamesListOfShortestPath = new List<string> { };
		for (int i = 0; i < shortestPath.Count; i++) {
			nodeNamesListOfShortestPath.Add(nodeNamesCollection[shortestPath[i]]);
		}

		int totalDistance = distance[destinationNode];

		ShortestPathData shortestPathData = new ShortestPathData();
		shortestPathData.Distance = totalDistance;
		shortestPathData.NodeNames = nodeNamesListOfShortestPath;

		return shortestPathData;
	}
}
