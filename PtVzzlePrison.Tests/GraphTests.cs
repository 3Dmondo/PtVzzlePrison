using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class GraphTests
    {
        /// <summary>
        /// All ones in the 3x4 matrix with indices:
        /// 0 1  2 3
        /// 4 5  6 7
        /// 8 9 10 11
        /// </summary>
        private static int[][] stars = new int[][] {
                new int[] { 1, 4 },
                new int[] { 0, 2, 5 },
                new int[] { 1, 3, 5 },
                new int[] { 2, 7 },

                new int[] { 0, 5, 8 },
                new int[] { 1, 4, 6, 9 },
                new int[] { 2, 5, 7, 10 },
                new int[] { 3, 6, 11 },

                new int[] { 4, 9 },
                new int[] { 5, 8, 10 },
                new int[] { 6, 9, 11 },
                new int[] { 7, 10 }
        };

        public static Graph TestGraph {get;} = new Graph(stars, 3, 4, (-1, -1));

        [TestMethod]
        public void ConstructorTest()
        {
            var graph = new Graph(stars, 3, 4, (-1, -1));
            Assert.IsNotNull(graph);
            Assert.AreEqual(3, graph.Rows);
            Assert.AreEqual(4, graph.Colums);
            Assert.AreEqual((-1,-1), graph.OpenLink);
            Assert.IsTrue(new IListIListComparer<int>().Equals(stars, graph.Stars));
        }

        [TestMethod]
        public void GetStarTest()
        {
            for ( int i = 0; i < 12; i++)
            {
                CollectionAssert.AreEqual(stars[i], TestGraph.GetStar(i).ToArray());
            }
        }
    }
}
