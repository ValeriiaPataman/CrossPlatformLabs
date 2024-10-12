using System;
using System.Collections.Generic;
using System.Linq;

namespace App;

public class PathFinder
{
    private readonly Graph _graph;
    private int _minCost = int.MaxValue;
    private List<int> _bestPath = new List<int>();
    private List<int> _bestChannelIndices = new List<int>();

    public PathFinder(Graph graph)
    {
        _graph = graph;
    }

    public void FindMinCostPath()
    {
        bool[] visited = new bool[_graph.N + 1];
        List<int> currentPath = new List<int>();
        List<int> currentChannelIndices = new List<int>();
        DFS(1, 0, visited, currentPath, currentChannelIndices);
    }

    private void DFS(int currentCity, int currentCost, bool[] visited, List<int> currentPath, List<int> currentChannelIndices)
    {
        visited[currentCity] = true;
        currentPath.Add(currentCity);

        if (AllCitiesVisited(visited))
        {
            if (currentCost < _minCost)
            {
                _minCost = currentCost;
                _bestPath = new List<int>(currentPath);
                _bestChannelIndices = new List<int>(currentChannelIndices);
            }
        }
        else
        {
            foreach (var edge in _graph.AdjacencyList[currentCity])
            {
                if (!visited[edge.v])
                {
                    currentChannelIndices.Add(edge.index); 
                    DFS(edge.v, currentCost + edge.cost, visited, currentPath, currentChannelIndices);
                    currentChannelIndices.RemoveAt(currentChannelIndices.Count - 1); 
                }
            }
        }

        visited[currentCity] = false;
        currentPath.RemoveAt(currentPath.Count - 1);
    }

    private bool AllCitiesVisited(bool[] visited)
    {
        for (int i = 1; i < visited.Length; i++)
        {
            if (!visited[i]) return false;
        }
        return true;
    }

    public (int cost, int[] channelIndices) GetResult()
    {
        return (_minCost, _bestChannelIndices.ToArray());
    }
}