using System;
using System.Linq;
using System.Collections.Generic;

namespace day21
{
    class Program
    {
        // state has a key of:
        //   which player turn|p1 pos,p1 score|p2 pos,p2 score
        // and a value of the count of universes in that state
        private static Dictionary<(int, int, int, int, int), long> states =
            new Dictionary<(int, int, int, int, int), long>();

        public static long p1wins = 0;
        public static long p2wins = 0;



        static void Main(string[] args)
        {
            string filename =
                //"input.txt";
                "input-example.txt";

            var input = new PuzzleInput(filename);
            //Part1(input);

            Part2();
        }

        private static void DumpPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }

        private static void Part1(PuzzleInput input)
        {
            var players = new List<Player>();
            foreach (var line in input.Lines)
            {
                players.Add(new Player(line));
            }
            var game = new Game();
            game.Players = players;

            bool win = false;
            while (!win)
            {
                win = game.TakeATurn();
            }

            int lowestScore = game.GetLowestScoringPlayer().Score;
            int numRolls = game.TotalDieRolls;

            Console.WriteLine($"Lowest score of {lowestScore} times num rolls of {numRolls} = {lowestScore * numRolls}");

        }

        private static void Part2()
        {

            (int, int, int, int, int) initialState = (
                1,
                2,
                0,
                5,
                0);

            // initially only one state exists and one univers
            states[initialState] = 1;

            int i = 0;
            // Continue this as long as states remain in the state dictionary
            while (states.Keys.Count > 0)
            {
                // * take one state out of the states dictionary
                (int, int, int, int, int) state = states.Keys.First();
                long numUniverses = states[state];
                states.Remove(state);

                Expand(state, 3, 1, numUniverses);
                Expand(state, 4, 3, numUniverses);
                Expand(state, 5, 6, numUniverses);
                Expand(state, 6, 7, numUniverses);
                Expand(state, 7, 6, numUniverses);
                Expand(state, 8, 3, numUniverses);
                Expand(state, 9, 1, numUniverses);

                Console.WriteLine($"{p1wins} | {p2wins} | {states.Count}");
                MoveToWins();
                if (i % 10_000_000_000 == 0)
                    Console.WriteLine($"{p1wins} | {p2wins} | {states.Count}");

                i++;
            }
            Console.WriteLine($"{p1wins} | {p2wins} | {states.Count}");

            // At each turn:
            // * for each of these possible outcomes:
            //        a roll of 3 happens in 1 universe
            //        a roll of 4 happens in 3 universes
            //        a roll of 5 happens in 6 uninverse
            //        a roll of 6 happens in 7 universes
            //        a roll of 7 happens in 6 universes
            //        a roll of 8 happens in 3 universes
            //        a roll of 9 happens in 1 universes
            //    - calculate the resulting score
            //    - change to the otheer player as next turn
            //    - either increment thee states dictionary with or add
            //      to states dictionary for each of these
            // * examine all states in the states dictionary and move any
            //   over to the winning state if needed

            //       
        }

        private static void Expand(
            (int, int, int, int, int) state, // starting state
            int roll, // the roll (combination of 3 rolls added)
            long numBaseUniverses,
            long numUniversesWithRoll // of the 27 new universes created in
                                      // this turn, how many got this roll
            )
        {
            var newState = State.Move(roll, state);

            if (!states.Keys.Contains(newState)) states[newState] = 0;

            states[newState] += numUniversesWithRoll * numBaseUniverses;
        }


        private static void MoveToWins()
        {
            int playerNum,
                p1pos,
                p1score,
                p2pos,
                p2score;
            var keysToRemove  = new List<(int, int, int, int, int)>();

            foreach (var key in states.Keys)
            {
                (playerNum, p1pos, p1score, p2pos, p2score) = key;

                if (p1score >= 21)
                {
                    p1wins += states[key];
                    keysToRemove.Add(key);
                }
                else if (p2score >= 21)
                {
                    p2wins += states[key];
                    keysToRemove.Add(key);
                }
            }

            foreach(var key in keysToRemove)
            {
                states.Remove(key);
            }
        }

    }
}
