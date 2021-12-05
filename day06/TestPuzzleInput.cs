using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day06
{
    [TestClass]
    public class TestPuzzleInput
    {
        [TestMethod]
        public void TestExampleInput()
        {
            PuzzleInput input = new PuzzleInput("input-example.txt");

            Assert.AreEqual("a", input.Lines[0]);
            Assert.AreEqual("b", input.Lines[1]);
        }
    }
}
