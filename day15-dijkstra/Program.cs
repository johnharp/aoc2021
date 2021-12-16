using System;

namespace day15_dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new PuzzleInput("input-example.txt");
            Map m = new Map(input.NumCols * 5, input.NumRows * 5);
            m.InitializeRiskValues(input.Lines, 5);

            m.DumpValues();
        }
    }
}
