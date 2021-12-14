namespace PtVzzlePrison
{
    public static class DijkstraSolver
    {
        public static Node Solve(Node root, int terminalId)
        {
            var extracted = new HashSet<int>();
            var costs = new Dictionary<int, int>();
            var queue = new PriorityQueue<Node, int>();
            queue.Enqueue(root, root.Cost);
            while (queue.TryDequeue(out var current, out _))
            {
                if (extracted.Add(current.Id))
                {
                    if (current.Id == terminalId)
                    {
                        return current;
                    }
                    foreach (Node node in current.Star())
                    {
                        if (!costs.TryGetValue(node.Id, out var prevCost) ||
                            node.Cost < prevCost)
                        {
                            costs[node.Id] = node.Cost;
                            queue.Enqueue(node, node.Cost);
                        }
                    }
                }
            }
            return Node.NotFound(root.Graph);
        }
    }
}
