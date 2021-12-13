using System;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filename = "input-example.txt";
            string filename = "input.txt";

            PuzzleInput input = new PuzzleInput(filename);
            DotTracker tracker = new DotTracker();
            tracker.CreateDots(input);

            tracker.DumpDotCount();

            tracker.DoFold(input.FoldLines[0]);
            tracker.DumpDotCount();

            //tracker.DoFold(input.FoldLines[1]);

            //tracker.DoFolds(input);
            //tracker.DumpDotCount();
        }
    }
}
