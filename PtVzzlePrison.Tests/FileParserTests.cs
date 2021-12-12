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
        [TestMethod]
        public void OneByOneResultsInNullAndMessage()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var value = FileParser.Parse(Files.not_valid_1x1); string expected =
                         $"{string.Format(FileParser.FileTooShort, Files.not_valid_1x1)}{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
            Assert.AreEqual(null, value);
        }
        [TestMethod]
        public void ClosedEntranceResultsInNullAndMessage()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var value = FileParser.Parse(Files.not_valid_2x2_1); string expected =
                         $"{string.Format(FileParser.EntryNodeClosed, Files.not_valid_2x2_1)}{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
            Assert.AreEqual(null, value);
        }
        [TestMethod]
        public void ClosedExitResultsInNullAndMessage()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var value = FileParser.Parse(Files.not_valid_2x2_2); string expected =
                         $"{string.Format(FileParser.ExitNodeClosed, Files.not_valid_2x2_2, "1", "1")}{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
            Assert.AreEqual(null, value);
        }
        [TestMethod]
        public void DifferentRowLengthsResultsInNullAndMessage()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var value = FileParser.Parse(Files.not_valid_2x2_3); string expected =
                         $"{string.Format(FileParser.AllRowMustBeEqual, Files.not_valid_2x2_3)}{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
            Assert.AreEqual(null, value);
        }
        [TestMethod]
        public void InvalidCharacterResultsInNullAndMessage()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var value = FileParser.Parse(Files.not_valid_2x2_4); string expected =
                         $"{string.Format(FileParser.InvlaidChars, Files.not_valid_2x2_4)}{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
            Assert.AreEqual(null, value);
        }
    }
}
