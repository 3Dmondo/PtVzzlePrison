using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class FileParserTests
    {
        [TestMethod]
        public void FileIsParsedCorrectly()
        {
            var expected = new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 } };
            var value = FileParser.Parse(Files.valid_2x2);
            CollectionAssert.AreEqual(expected[0], value?[0]);
            CollectionAssert.AreEqual(expected[1], value?[1]);

        }
    }
}
