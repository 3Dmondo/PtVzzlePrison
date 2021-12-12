namespace PtVzzlePrison
{
    internal static class StarBuilder
    {
        public static IList<IList<int>> Create(int[][] parsed)
        {
            var rows = parsed.Length;
            var colums = parsed[0].Length;
            var result = new IList<int>[rows * colums];
            for (int i = 0; i < rows * colums; i++)
            {
                result[i] = new List<int>();
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    if (parsed[i][j] == 1)
                    {
                        if (i + 1 < rows && parsed[i + 1][j] == 1)
                        {
                            result[(i, j).ToFlatIndex(colums)].Add((i + 1, j).ToFlatIndex(colums));
                            result[(i + 1, j).ToFlatIndex(colums)].Add((i, j).ToFlatIndex(colums));
                        }
                        if (j + 1 < colums && parsed[i][j + 1] == 1)
                        {
                            result[(i, j).ToFlatIndex(colums)].Add((i, j + 1).ToFlatIndex(colums));
                            result[(i, j + 1).ToFlatIndex(colums)].Add((i, j).ToFlatIndex(colums));
                        }
                    }
                }
            }
            return result;
        }
    }
}
