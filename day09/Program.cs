using System;

namespace day09
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleInput input = new PuzzleInput("input.txt");
            Map m = new Map(input.Lines);

            long sum = m.SumRiskLevels();
            Console.Out.WriteLine($"Total risk level: {sum}");
            
        }
    }
}
