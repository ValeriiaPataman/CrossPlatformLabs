using App;
using System;
using System.IO;
using Xunit;

public class PathFinderTests
{
    [Fact]
    public void TestMinimumCostPath()
    {
        var graph = new Graph(3);
        graph.AddEdge(1, 2, 5, 1);
        graph.AddEdge(1, 3, 10, 2);
        graph.AddEdge(3, 2, 1, 3);
        var pathFinder = new PathFinder(graph);

        pathFinder.FindMinCostPath();
        var result = pathFinder.GetResult();

        Assert.Equal(11, result.cost); 
        Assert.Equal(new[] { 2, 3 }, result.channelIndices);
    }


    [Fact]
    public void TestMinimumCostPath_AnotherScenario()
    {
        var graph = new Graph(3);
        graph.AddEdge(1, 2, 5, 1);
        graph.AddEdge(1, 3, 10, 2);
        graph.AddEdge(2, 3, 4, 3);
        var pathFinder = new PathFinder(graph);

        pathFinder.FindMinCostPath();
        var result = pathFinder.GetResult();

        Assert.Equal(9, result.cost);
        Assert.Equal(new[] { 1, 3 }, result.channelIndices);
    }
}