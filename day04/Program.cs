using System;
using System.Collections.Generic;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleInput input = new PuzzleInput("input.txt");

            Card firstWinner = null;
            Card mostRecentWinner = null;

            foreach(var num in input.CalledNumbers)
            {
                foreach(var card in input.Cards)
                {
                    if (card.MarkNumber(num))
                    {
                        if (firstWinner == null) firstWinner = card;
                        mostRecentWinner = card;
                    }
                }
            }

            Console.Out.WriteLine(
                $"First card to win has score: {firstWinner.score}");
            Console.Out.WriteLine(
                $"Last card to win has score: {mostRecentWinner.score}");
        }
    }
}
