using System;
using System.Collections.Generic;

namespace day21
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename =
                //"input.txt";
                "input.txt";

            var input = new PuzzleInput(filename);

            var players = new List<Player>();
            foreach(var line in input.Lines)
            {
                players.Add(new Player(line));
            }
            var game = new Game();
            game.Players = players;

            bool win = false;
            while(!win)
            {
                win = game.TakeATurn();
            }

            int lowestScore = game.GetLowestScoringPlayer().Score;
            int numRolls = game.TotalDieRolls;

            Console.WriteLine($"Lowest score of {lowestScore} time num rolls of {numRolls} = {lowestScore * numRolls}");
        }

        private static void DumpPlayers(List<Player> players)
        {
            foreach(var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
