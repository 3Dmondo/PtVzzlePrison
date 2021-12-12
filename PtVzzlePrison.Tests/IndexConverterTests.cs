using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class IndexConverterTests
    {
        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(10, 5)]
        [DataRow(5, 10)]
        public void ToMatrixIndicesTest(int rows, int columns)
        {
            int StartIndex = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    Assert.AreEqual((i, j), StartIndex++.ToMatrixIndices(columns));
        }

        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(10, 5)]
        [DataRow(5, 10)]
        public void ToFlatIndexTest(int rows, int columns)
        {
            int expected = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    Assert.AreEqual(expected++, (i, j).ToFlatIndex(columns));
        }
    }
}
