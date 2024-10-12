using App;
using System;
using System.IO;
using Xunit;


public class GraphTests
{
	[Fact]
	public void TestAddEdge()
	{
		var graph = new Graph(3);

		graph.AddEdge(1, 2, 5, 1);
		graph.AddEdge(1, 3, 10, 2);

		Assert.Equal(2, graph.AdjacencyList[1].Count); 
		Assert.Equal(5, graph.AdjacencyList[1][0].cost); 
	}
}