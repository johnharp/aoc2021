using System;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = "input.txt";
            PuzzleInput input = new PuzzleInput(filename);

            Tally t = new Tally(input.Lines);
            t.Dump();
        }
    }
}
