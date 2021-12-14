using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class NodeTests
    {

        public static Node PredecessorOfPredecessorNode { get; } = new Node(0, null, 0, GraphTests.TestGraph);
        public static Node PredecessorNode { get; } = new Node(4, PredecessorOfPredecessorNode, 1, GraphTests.TestGraph);
        private static Node TestNode { get; } = new Node(5, PredecessorNode, 2, GraphTests.TestGraph);

        [TestMethod]
        public void ConstructorTest()
        {
            Node node = new Node(5, PredecessorNode, 2, GraphTests.TestGraph);
            Assert.AreEqual(node.Id, 5);
            Assert.AreEqual(node.Predecessor, PredecessorNode);
            Assert.AreEqual(node.Cost, 2);
            Assert.AreEqual(node.Graph, GraphTests.TestGraph);
        }

        [TestMethod]
        public void NotFoundTest()
        {
            var node = Node.NotFound(GraphTests.TestGraph);
            Assert.AreEqual(-1, node.Id);
            Assert.IsNull(node.Predecessor);
            Assert.AreEqual(int.MaxValue, node.Cost);
            Assert.AreEqual(Node.NotFound(GraphTests.TestGraph), node);
        }

        [TestMethod]
        public void StarTest()
        {
            var expectedIndices = new int[] { 1, 4, 6, 9 };
            var stars = TestNode.Star().ToArray();
            for (int i = 0; i < stars.Length; i++)
            {
                Assert.AreEqual(stars[i].Id, expectedIndices[i]);
                Assert.AreEqual(stars[i].Cost, 3);
                Assert.AreEqual(stars[i].Predecessor, TestNode);
                Assert.AreEqual(stars[i].Graph, GraphTests.TestGraph);
            }
        }

        [TestMethod]
        public void EqualsTest()
        {
            var firstNode = TestNode;
            var secondNode = TestNode;
            var thirdNode = TestNode.Star().First();
            Assert.IsTrue(firstNode.Equals(secondNode));
            Assert.IsTrue(firstNode.Equals((object)firstNode));
            Assert.IsFalse(firstNode.Equals(thirdNode));
            Assert.IsFalse(firstNode.Equals(GraphTests.TestGraph));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Assert.AreEqual(HashCode.Combine(5), TestNode.GetHashCode());
        }

        [TestMethod]
        public void ReversePathTest()
        {
            var expectedPath = new Node[] { TestNode, PredecessorNode, PredecessorOfPredecessorNode };
            CollectionAssert.AreEqual(expectedPath, TestNode.ReversePath().ToArray());
        }
    }
}
