using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day04
{
    public class PuzzleInput
    {
        public String[] CalledNumbers;
        public List<Card> Cards;

        public PuzzleInput(string filename)
        {
            string[] lines = File.ReadLines($"../../../{filename}").ToArray();
            CalledNumbers = lines[0].Split(",");

            int i = 2;

            Cards = new List<Card>();

            while (i < lines.Length)
            {
                Card card = new Card(
                    lines[i],
                    lines[i + 1],
                    lines[i + 2],
                    lines[i + 3],
                    lines[i + 4]);
                Cards.Add(card);
                
                i += 6;
            }

        }

        public bool AnyCardWin()
        {
            foreach (var card in Cards)
            {
                if (card.win)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
