using System;

namespace day15_dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new PuzzleInput("input-example.txt");

            // Part 2 involves "tiling" the input across and down
            // 5 times.  The risk value of each node increases by 1
            // for each position change right or down.
            input.CreateNodes(numTiles: 5);
            var n = Node.Get(1, 49);
            var a = n.NonFinalNeighbors();
        }
    }
}
