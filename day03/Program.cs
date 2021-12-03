using System;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            RunExample();
        }

        static void RunExample()
        {
            PuzzleInput input = new PuzzleInput();
            var lines = input.Example();

            Tally t = new Tally(lines);
            int gamma = t.gamma;
            int epsilon = t.epsilon;

            Console.Out.WriteLine($"Gamma = {t.gamma}");
            Console.Out.WriteLine($"Epsilon = {t.epsilon}");
            Console.Out.WriteLine($"Their product = {t.gamma * t.epsilon}");

            Console.Out.WriteLine();

            Console.Out.WriteLine($"Oxygen Gen Rating = {t.oxGenRating}");
            Console.Out.WriteLine($"CO2 Scrubber Rating = {t.co2ScrubRating}");
            Console.Out.WriteLine($"Their product = {t.oxGenRating * t.co2ScrubRating}");


        }
    }
}
