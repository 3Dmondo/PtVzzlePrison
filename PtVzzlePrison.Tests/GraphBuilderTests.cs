using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class GraphBuilderTests
    {
        [TestMethod]
        public void CloneTest()
        {
            var original = new int[][] {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            };
            var clone = GraphBuilder.Clone(original);
            Assert.IsTrue(new IListIListComparer<int>().Equals(original, clone));
        }

        [TestMethod]
        public void GetAllPossibleGraphsTest()
        {
            var original = new int[][] {
                new int[] {1, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 1}
            };
            var expected = new (int, int, int[][])[] {
                (-1, -1, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {0, 0, 0},
                    new int[] {0, 0, 1}
                }),
                (0, 1, new int[][] {
                    new int[] {1, 1, 0},
                    new int[] {0, 0, 0},
                    new int[] {0, 0, 1}
                }),
                (0, 2, new int[][] {
                    new int[] {1, 0, 1},
                    new int[] {0, 0, 0},
                    new int[] {0, 0, 1}
                }),
                (1, 0, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {1, 0, 0},
                    new int[] {0, 0, 1}
                }),
                (1, 1, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {0, 1, 0},
                    new int[] {0, 0, 1}
                }),
                (1, 2, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {0, 0, 1},
                    new int[] {0, 0, 1}
                }),
                (2, 0, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {0, 0, 0},
                    new int[] {1, 0, 1}
                }),
                (2, 1, new int[][] {
                    new int[] {1, 0, 0},
                    new int[] {0, 0, 0},
                    new int[] {0, 1, 1}
                }),
            };

            var possibleGraphs = GraphBuilder.GetAllPossibleGraphs(original);
            foreach (var graph in possibleGraphs)
            {
                Assert.IsTrue(expected.Contains(graph, new TripleComparer()));
            }
            Assert.AreEqual(expected.Length, possibleGraphs.Count());
        }

        [TestMethod]
        public void BuildGraphsTest()
        {
            var parsed = new int[][] {
                new int[] {1, 1, 0},
                new int[] {0, 1, 0},
                new int[] {0, 1, 1}
            };
            var expected = new int[][] {
                new int[] { 1 },
                new int[] { 0, 4 },
                new int[] { },
                new int[] { },
                new int[] { 1, 7 },
                new int[] { },
                new int[] { },
                new int[] { 4, 8 },
                new int[] { 7 }};


            var graph = GraphBuilder.BuildGraphs(parsed).First();
            Assert.IsTrue(new IListIListComparer<int>().Equals(expected, graph.Stars));

            var graphs = GraphBuilder.BuildGraphs(parsed);
            Assert.AreEqual(5, graphs.Count());
        }
    }
}
