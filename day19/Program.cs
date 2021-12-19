using System;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input-example.txt";
            // string filename = "input.txt";
            var input = new PuzzleInput(filename);

            var scanners = input.Scanners;

            var orientations = Orientation.PossibleOrientations();
        }
    }
}
