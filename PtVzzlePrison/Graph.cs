namespace PtVzzlePrison
{
    public class Graph
    {
        public (int, int) OpenLink { get; }

        public Graph(int[][] stars, (int,int) openLink)
        {
            Stars = stars;
            OpenLink = openLink;
        }

        private int[][] Stars;

        public IEnumerable<int> GetStar(int id)
        {
            for (int i = 0; i < Stars[id].Length; i++)
            {
                yield return Stars[id][i];
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Graph graph &&
                   OpenLink.Equals(graph.OpenLink);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OpenLink);
        }
    }
}