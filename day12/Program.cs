using System;
using System.Collections.Generic;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            PuzzleInput input = new PuzzleInput(filename);
            Cave.ParseInput(input);
            Cave.DumpAll();

            Cave start = Cave.Caves["start"];

            List<Cave> closedCaves = new List<Cave>();

            int numpaths = start.CountPaths(closedCaves);

            Console.Out.WriteLine($"Total paths = {numpaths}");
        }
    }
}
