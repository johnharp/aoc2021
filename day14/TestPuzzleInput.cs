using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day14
{
    [TestClass]
    public class TestPuzzleInput
    {
        [TestMethod]
        public void TestExampleInput()
        {
            PuzzleInput input = new PuzzleInput("input-example.txt");
            Assert.AreEqual(10, input.Lines.Length);
        }
    }
}
