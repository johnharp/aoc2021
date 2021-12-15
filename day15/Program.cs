using System;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            var input = new PuzzleInput(filename);
            var map = new Map(input.Lines);
            Part1(map);
        }

        private static void Part1(Map map)
        {
            map.ComputeLeastPathSums();
            Console.WriteLine($"Least path sum: {map.LPS[0][0]}");
        }
    }
}
