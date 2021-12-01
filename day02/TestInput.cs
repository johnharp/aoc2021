using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day02
{
    [TestClass]
    public class TestInput
    {
        [TestMethod]
        public void TestExampleInput()
        {
            PuzzleInput input = new PuzzleInput();
            var lines = input.Example();

            Assert.AreEqual(0, lines.Length);
        }
    }
}
