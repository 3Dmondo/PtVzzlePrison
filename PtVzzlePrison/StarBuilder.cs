namespace PtVzzlePrison
{
    internal static class StarBuilder
    {
        public static IList<IList<int>> Create(int[][] parsed)
        {
            var rows = parsed.Length;
            var columns = parsed[0].Length;
            var result = new IList<int>[rows * columns];
            for (int i = 0; i < rows * columns; i++)
            {
                result[i] = new List<int>();
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (parsed[i][j] == 1)
                    {
                        if (i + 1 < rows && parsed[i + 1][j] == 1)
                        {
                            result[(i, j).ToFlatIndex(columns)].Add((i + 1, j).ToFlatIndex(columns));
                            result[(i + 1, j).ToFlatIndex(columns)].Add((i, j).ToFlatIndex(columns));
                        }
                        if (j + 1 < columns && parsed[i][j + 1] == 1)
                        {
                            result[(i, j).ToFlatIndex(columns)].Add((i, j + 1).ToFlatIndex(columns));
                            result[(i, j + 1).ToFlatIndex(columns)].Add((i, j).ToFlatIndex(columns));
                        }
                    }
                }
            }
            return result;
        }
    }
}
