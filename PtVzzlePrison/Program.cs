using PtVzzlePrison;
return Runner.Run(args); //this line is not tested
public static class Runner 
{ 
    public static int Run(string[] args)
    {
        if (!ArgumentsParser.ValidateArguments(args)) return -1;
        var parsedGraph = FileParser.Parse(args[0]);
        if (parsedGraph == null) return -1;
        var graphs = GraphBuilder.BuildGraphs(parsedGraph);
        var results = new List<Node>();
        foreach (var graph in graphs)
        {
            results.Add(DijkstraSolver.Solve(
                new Node(0, null, 0, graph), 
                graph.Colums * graph.Rows - 1));
        }
        var bestResult = Node.NotFound(graphs.First());
        foreach (var result in results)
        {
            if (result.Cost < bestResult.Cost)
            {
                bestResult = result;
            }
        }
        var outputFile = Path.ChangeExtension(args[0], ".solution");
        File.WriteAllText(outputFile, ResultWriter.Write(bestResult));
        return 0;
    }
}
