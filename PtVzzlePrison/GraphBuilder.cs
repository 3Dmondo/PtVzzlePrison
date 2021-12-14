namespace PtVzzlePrison
{
    internal static class GraphBuilder
    {
        internal static IEnumerable<Graph> BuildGraphs(int[][] parsedGraph)
        {
            var rows = parsedGraph.Length;
            var columns = parsedGraph[0].Length;
            foreach (var ithGraph in GetAllPossibleGraphs(parsedGraph))
            {
                var stars = StarBuilder.Create(ithGraph.Item3);
                yield return new Graph(stars, rows, columns, (ithGraph.Item1, ithGraph.Item2));
            }
        }

        internal static IEnumerable<(int, int, int[][])> GetAllPossibleGraphs(int[][] original)
        {
            yield return (-1, -1, original);
            for (int i = 0; i < original.Length; i++)
            {
                for (int j = 0; j < original[i].Length; j++)
                {
                    if (original[i][j] == 0)
                    {
                        var clone = Clone(original);
                        clone[i][j] = 1;
                        yield return (i, j, clone);
                    }
                }
            }
        }

        internal static int[][] Clone(int[][] original)
        {
            var clone = new int[original.Length][];
            for (int i = 0; i < original.Length; i++)
            {
                clone[i] = (int[])original[i].Clone();
            }
            return clone;
        }
    }
}
