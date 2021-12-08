using System;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleInput input = new PuzzleInput("input.txt");

            Part1(input);
        }

        private static void Part1(PuzzleInput input)
        {
            int oneFourSevenEightCount = 0;

            foreach (var line in input.Lines)
            {
                string[] patterns;
                string[] outputs;

                (patterns, outputs) = SplitLine(line);

                // 1: 2 segments
                // 4: 4 segments
                // 7: 3 segments
                // 8: 7 segments

                foreach (var output in outputs)
                {
                    int length = output.Length;

                    if (length == 2 || length == 4 || length == 3 || length == 7)
                    {
                        oneFourSevenEightCount++;
                    }
                }
            }

            Console.Out.WriteLine($"Part 1 - count of 1, 4, 7, 8: {oneFourSevenEightCount}");
        }


        // split apart an input line
        // the left side before the "|" has 10 examples of the
        // signal patterns for 0, 1, 2, ... 10 (in a random order)
        // the right side after the "|" has a 4-digit number "output"
        // displayed using these patterns
        private static (string[], string[]) SplitLine(string line)
        {
            string[] parts = line.Split(" | ");
            string[] patterns = parts[0].Split(" ");
            string[] outputs = parts[1].Split(" ");

            return (patterns, outputs);
        }



    }
}
