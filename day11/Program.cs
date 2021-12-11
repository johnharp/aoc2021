using System;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input-example.txt";
            PuzzleInput input = new PuzzleInput(filename);
            Map map = new Map(input.Lines);

            map.Dump();
            map.Step();
            Console.WriteLine("----------------------------");
            map.Dump();
        }
    }
}
