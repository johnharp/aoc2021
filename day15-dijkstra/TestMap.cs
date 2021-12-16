using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day15_dijkstra
{
    [TestClass]
    public class TestMap
    {
        [TestMethod]
        public void TestNeighbors()
        {
            var input = new PuzzleInput("input-example.txt");
            Map m = new Map(input.NumCols, input.NumRows);
            m.InitializeRiskValues(input.Lines);

            var neighbors = m.NonFinalNeighbors(0, 0);
            Assert.AreEqual(2, neighbors.Count);
            Assert.AreEqual(0, neighbors[1].Item1);
            Assert.AreEqual(1, neighbors[1].Item2);

            Assert.AreEqual(1, neighbors[0].Item1);
            Assert.AreEqual(0, neighbors[0].Item2);

        }
    }
}
