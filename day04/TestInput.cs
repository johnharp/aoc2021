using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day04
{
    [TestClass]
    public class TestInput
    {
        [TestMethod]
        public void TestExampleInput()
        {
            PuzzleInput input = new PuzzleInput("input-example");

            Assert.AreEqual(26, input.CalledNumbers.Length);
        }
    }
}
