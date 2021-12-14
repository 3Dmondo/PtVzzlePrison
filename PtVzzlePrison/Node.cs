namespace PtVzzlePrison
{
    public class Node : IEquatable<Node>
    {
        public Node(int id, Node? predecessor, int cost, Graph graph) 
        {
            Predecessor = predecessor;
            Id = id;
            Cost = cost;
            Graph = graph;
        }

        public int Id { get; }
        public int Cost { get; }
        public Node? Predecessor { get; }
        public Graph Graph { get; }

        public IEnumerable<Node> Star()
        {
            foreach (int nodeId in Graph.GetStar(Id))
            {
                yield return new Node(nodeId, this, Cost + 1, Graph);
            }
        }

        public IEnumerable<Node> ReversePath()
        {
            yield return this;
            var prevNode = Predecessor;
            while (prevNode != null)
            {
                yield return prevNode;
                prevNode=prevNode.Predecessor;
            }
        }

        public static Node NotFound(Graph graph)
        {
            return new(-1, null, -1, graph);
        }

        public override bool Equals(object? obj)
        {
            return obj is Node node && Equals(node);
        }

        public bool Equals(Node other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
