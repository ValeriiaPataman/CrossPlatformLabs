using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library
{
    public static class IOHandler3
    {
        public static (Graph graph, int citiesCount) ReadDataFromFile(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new Exception($"File {inputFilePath} was not found.");
            }

            var lines = File.ReadAllLines(inputFilePath)
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            if (lines.Length < 3)
            {
                throw new Exception("Wrong number of lines in file.");
            }

            var firstLine = lines[0].Split(' ');
            int n = int.Parse(firstLine[0]);
            int m = int.Parse(firstLine[1]);

            Graph graph = new Graph(n);

            for (int i = 1; i <= m; i++)
            {
                var parts = lines[i].Split(' ');
                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);
                int cost = int.Parse(parts[2]);
                graph.AddEdge(u, v, cost, i);
            }

            return (graph, n);
        }

        public static void WriteResultToFile(int cost, int[] channelIndices, string outputFilePath)
        {
            if (Directory.Exists(outputFilePath))
            {
                outputFilePath = Path.Combine(outputFilePath, "OUTPUT.TXT");
            }
            File.WriteAllText(outputFilePath, $"{cost} {channelIndices.Length}\n{string.Join(" ", channelIndices)}");
        }
    }

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

    public static class Lab3
    {
        public static void Run(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine($"Input File Path: {inputFilePath}");
            Console.WriteLine($"Output File Path: {outputFilePath}");
            Console.OutputEncoding = Encoding.Unicode;

            Graph graph;
            int citiesCount;

            try
            {
                (graph, citiesCount) = IOHandler3.ReadDataFromFile(inputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading the file: {e.Message}");
                return;
            }

            PathFinder pathFinder = new PathFinder(graph);
            pathFinder.FindMinCostPath();

            var result = pathFinder.GetResult();
            try
            {
                IOHandler3.WriteResultToFile(result.cost, result.channelIndices, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error writing to the file: {e.Message}");
            }
        }
    }
}
