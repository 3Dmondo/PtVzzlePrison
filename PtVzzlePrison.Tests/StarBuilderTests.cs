using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class StarBuilderTests
    {
        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(10, 5)]
        [DataRow(5, 10)]
        public void FullyConnectedGraphIsCorrect(int rows, int columns)
        {
            var input = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                input[i] = new int[columns];
                for (var j = 0; j < columns; j++)
                {
                    input[i][j] = 1;
                }
            }
            var output = StarBuilder.Create(input);
            Assert.AreEqual(rows * columns, output.Count);
            for (var k = 0; k < rows * columns; k++)
            {
                var matrixIndices = k.ToMatrixIndices(columns);
                var expectedStar = new List<(int, int)>();
                AddRows(rows, matrixIndices, expectedStar);
                AddColumns(columns, matrixIndices, expectedStar);
                foreach (var matrixIndex in expectedStar)
                {
                    Assert.IsTrue(output[k].Contains(matrixIndex.ToFlatIndex(columns)));
                }

            }
        }
        private static void AddRows(int rows, (int,int) matrixIndex, List<(int, int)> expectedStar)
        {
            if (matrixIndex.Item1 + 1 < rows)
            {
                expectedStar.Add((matrixIndex.Item1 + 1, matrixIndex.Item2));
            }
            if (matrixIndex.Item1 - 1 >= 0)
            {
                expectedStar.Add((matrixIndex.Item1 - 1, matrixIndex.Item2));
            }
        }
        private static void AddColumns(int columns, (int, int) matrixIndex, List<(int, int)> expectedStar)
        {
            if (matrixIndex.Item2 + 1 < columns)
            {
                expectedStar.Add((matrixIndex.Item1, matrixIndex.Item2 + 1));
            }
            if (matrixIndex.Item2 - 1 >= 0)
            {
                expectedStar.Add((matrixIndex.Item1, matrixIndex.Item2 - 1));
            }
        }
    }
}
