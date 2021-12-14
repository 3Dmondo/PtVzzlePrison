
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PtVzzlePrison.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [DataRow(Files.valid_2x2)]
        [DataRow(Files.not_connected_2x2)]
        [DataRow(Files.not_solvable_2x3)]
        public void MainTest(string fileName)
        {
            Assert.AreEqual(0, Runner.Run(new string[] { fileName }));
            var expected = Path.ChangeExtension(fileName, ".expected");
            var solution = Path.ChangeExtension(fileName, ".solution");
            Assert.AreEqual(File.ReadAllText(expected), File.ReadAllText(solution));
        }

        [TestMethod]
        public void InvalidArgument()
        {
            Assert.AreEqual(-1, Runner.Run(Array.Empty<string>()));
        }

        [TestMethod]
        public void InvalidGraph()
        {
            Assert.AreEqual(-1, Runner.Run(new string[] { Files.not_valid_2x2_1 }));
        }
    }

}
