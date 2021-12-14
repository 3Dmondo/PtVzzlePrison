using System.Text;
namespace PtVzzlePrison
{
    internal class ResultWriter
    {
        internal static string Write(Node bestResult)
        {
            if (bestResult.Id == -1) return String.Empty;
            int[][] outputMatrix = GenerateEmptyMatrix(bestResult.Graph.Rows, bestResult.Graph.Colums);
            foreach (var node in bestResult.ReversePath())
            {
                var indices = IndexConverter.ToMatrixIndices(node.Id, bestResult.Graph.Colums);
                outputMatrix[indices.Item1][indices.Item2] = 1;
            }
            var sw = new StringBuilder();
            foreach (var row in outputMatrix)
            {
                sw.AppendLine(String.Join(" ", row));
            }
            sw.AppendLine();
            sw.AppendLine(bestResult.Cost.ToString());
            if (bestResult.Graph.OpenLink != (-1, -1))
            {
                sw.AppendLine();
                sw.AppendLine($"{bestResult.Graph.OpenLink.Item1} {bestResult.Graph.OpenLink.Item2}");
            }
            return sw.ToString();
        }

        private static int[][] GenerateEmptyMatrix(int rows, int colums)
        {
            var output = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                output[i] = Enumerable.Repeat(0, colums).ToArray();
            }
            return output;
        }
    }
}