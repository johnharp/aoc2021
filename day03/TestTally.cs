using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day03
{
    [TestClass]
    public class TestTally
    {
        [TestMethod]
        public void TestTallyClass()
        {
            PuzzleInput input = new PuzzleInput();
            string[] lines = input.Example();

            Tally t = new Tally(lines);

            Assert.AreEqual(5, t.zeroCounts[0]);
            Assert.AreEqual(7, t.oneCounts[0]);

            Assert.AreEqual(7, t.zeroCounts[4]);
            Assert.AreEqual(5, t.oneCounts[4]);

            Assert.AreEqual(22, t.gamma);
            Assert.AreEqual(9, t.epsilon);
        }
    }
}
