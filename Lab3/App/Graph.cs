using System;
using System.Collections.Generic;
using System.Linq;

namespace App;

public class Graph
{
    public class Edge
    {
        public int v; 
        public int cost; 
        public int index; 

        public Edge(int v, int cost, int index)
        {
            this.v = v;
            this.cost = cost;
            this.index = index;
        }
    }

    public List<Edge>[] AdjacencyList;
    public int N; 

    public Graph(int n)
    {
        N = n;
        AdjacencyList = new List<Edge>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            AdjacencyList[i] = new List<Edge>();
        }
    }

    public void AddEdge(int u, int v, int cost, int index)
    {
        AdjacencyList[u].Add(new Edge(v, cost, index));
    }
}