using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{

    [TestClass]
    public class DijkstraSolverTest
    {

        private static int[][] Solvable = new int[][]
        {
            new int[] {1, 1, 0},
            new int[] {0, 1, 0},
            new int[] {0, 1, 1}
        };

        private static int[][] NotSolvable = new int[][]
        {
            new int[] {1, 1, 0},
            new int[] {0, 0, 0},
            new int[] {0, 0, 1}
        };

        private static Graph SolvableGraph = new Graph(StarBuilder.Create(Solvable), 3, 3, (-1, -1));
        private static Graph NotSolvableGraph = new Graph(StarBuilder.Create(NotSolvable), 3, 3, (-1, -1));

        [TestMethod]
        public void NotSolvableGraphReturnNotFoundNode()
        {
            var result = DijkstraSolver.Solve(new Node(0, null, 0, NotSolvableGraph), 8);
            Assert.AreEqual(Node.NotFound(NotSolvableGraph), result);
        }

        [TestMethod]
        public void SolvableGraphReturnCorrectSolution()
        {
            var node0 = new Node(0, null, 0, SolvableGraph);
            var node1 = new Node(1, node0, 1, SolvableGraph);
            var node4 = new Node(4, node1, 2, SolvableGraph);
            var node7 = new Node(7, node4, 3, SolvableGraph);
            var node8 = new Node(8, node7, 4, SolvableGraph);

            var result = DijkstraSolver.Solve(new Node(0, null, 0, SolvableGraph), 8);

            CollectionAssert.AreEqual(
                node8.ReversePath().Select(n => (n.Id, n.Cost)).ToArray(),
                result.ReversePath().Select(n => (n.Id, n.Cost)).ToArray());
        }
    }
}
