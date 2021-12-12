using System;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input-example1.txt";
            PuzzleInput input = new PuzzleInput(filename);
            foreach(var line in input.Lines)
            {
                Cave.ParsePath(line);
            }

            Cave.DumpAll();
        }
    }
}
