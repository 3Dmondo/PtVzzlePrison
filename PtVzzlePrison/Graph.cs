namespace PtVzzlePrison
{
    public class Graph
    {
        public (int, int) OpenLink { get; }
        public int Rows { get; }
        public int Colums { get; }
        private IList<IList<int>> Stars { get; }

        public Graph(IList<IList<int>> stars, int rows, int columns, (int, int) openLink)
        {
            Stars = stars;
            OpenLink = openLink;
            Rows = rows;
            Colums = columns;
        }
        public IEnumerable<int> GetStar(int id)
        {
            for (int i = 0; i < Stars[id].Count; i++)
            {
                yield return Stars[id][i];
            }
        }
    }
}