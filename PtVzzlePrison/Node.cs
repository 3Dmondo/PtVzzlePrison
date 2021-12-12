namespace PtVzzlePrison
{
    public struct Node : IEquatable<Node>
    {
        public Node(int id, int predecessor, int cost, Graph graph) : this()
        {
            Predecessor = predecessor;
            Id = id;
            Cost = cost;
            Graph = graph;
        }

        public int Id { get; }
        public int Cost { get; }
        public int Predecessor { get; }
        public Graph Graph { get; }
        public IEnumerable<Node> Star()
        {
            foreach (int nodeId in Graph.GetStar(Id))
            {
                yield return new Node(nodeId, Id, Cost + 1, Graph);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Node node && Equals(node);
        }

        public bool Equals(Node other)
        {
            return Id == other.Id &&
                   Cost == other.Cost &&
                   Predecessor == other.Predecessor &&
                   EqualityComparer<Graph>.Default.Equals(Graph, other.Graph);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Cost, Predecessor, Graph);
        }

        public static Node NotFound(Graph graph)
        {
            return new(-1, -1, -1, graph);
        }
    }
}
