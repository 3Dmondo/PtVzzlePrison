
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class ArgumentsParserTests
    {

        [TestMethod]
        public void WrongNumberArgumentListPrintErrorAndReturnFalse()
        {
            for (int i = 0; i < 3; i += 2)
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    var result = ArgumentsParser.ValidateArguments(Enumerable.Range(0, i).
                        Select(s => s.ToString() + ".txt").
                        ToArray());
                    string expected =
                        $"{string.Format(ArgumentsParser.WrongNumberOfArguments, i)}{Environment.NewLine}";
                    Assert.AreEqual(expected, sw.ToString());
                    Assert.IsFalse(result);
                }
        }

        [TestMethod]
        public void NonExistingFilePrintErrorAndReturnFalse()
        {
            using (StringWriter sw = new StringWriter())
            {
                var fileName = "fileName.txt";
                Console.SetOut(sw);
                var result = ArgumentsParser.ValidateArguments(new string[] { fileName });
                string expected =
                    $"{string.Format(ArgumentsParser.FileDoesNotExist, fileName)}{Environment.NewLine}";
                Assert.AreEqual(expected, sw.ToString());
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void FileExist()
        {
            using (StringWriter sw = new StringWriter())
            {
                var fileName = "Resources/2by2-valid.txt";
                Console.SetOut(sw);
                var result = ArgumentsParser.ValidateArguments(new string[] { fileName });
                string expected =
                    $"{string.Format(ArgumentsParser.FileExist, fileName)}{Environment.NewLine}";
                Assert.AreEqual(expected, sw.ToString());
                Assert.IsTrue(result);
            }
        }
    }
}