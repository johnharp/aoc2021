using System;
using System.Collections.Generic;

namespace day03
{
    public class Tally
    {
        public int[] oneCounts = null;
        public int[] zeroCounts = null;
        public int length = -1; // length of one line
        public int numLines = -1; // number of input lines
        public char[] mostCommon;
        public char[] leastCommon;

        public int gamma { get; set; }
        public int epsilon { get; set; }

        public int oxGenRating { get; set; }
        public int co2ScrubRating { get; set; }

        private char[][] input;

        public Tally(string[] lines)
        {
            StructureInput(lines);
            CountOnesZerosPerBitPosition(lines);
            CalculatePartOne();
            CalculatePartTwo(lines);
        }

        // since we're doing a log of indexing into the
        // input (line by line) and within each line (by char
        // position) it makes sense to first create a two-dimensional
        // character array.

        // first index is the line
        // second index is for the character position in the line
        // arranged with most-significant-bit in position 0
        private void StructureInput(string[] lines)
        {
            numLines = lines.Length;
            input = new char[numLines][];
            length = lines[0].Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                input[i] = line.ToCharArray();
            }
        }
       
        private void CountOnesZerosPerBitPosition(string[] lines)
        {
            oneCounts = new int[length];
            zeroCounts = new int[length];

            foreach (char[] characters in input)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    char c = characters[i];

                    if (c == '0') zeroCounts[i]++;
                    else if (c == '1') oneCounts[i]++;
                    else throw new Exception("Invalid character in input");
                }
            }

            mostCommon = new char[length];
            leastCommon = new char[length];

            for (int i = 0; i<length; i++)
            {
                if (oneCounts[i] > zeroCounts[i])
                {
                    mostCommon[i] = '1';
                    leastCommon[i] = '0';
                }
                else if (zeroCounts[i] > oneCounts[i])
                {
                    mostCommon[i] = '0';
                    leastCommon[i] = '1';
                }
                else
                {
                    mostCommon[i] = '?';
                    leastCommon[i] = '?';
                }
            }
        }

        private void CalculatePartOne()
        {
            char[] gammaBits = new char[length];
            char[] epsilonBits = new char[length];

            for (int i = 0; i < length; i++)
            {
                gammaBits[i] = mostCommon[i];
                epsilonBits[i] = leastCommon[i];
            }

            gamma = CalculateValueFromBits(gammaBits);
            epsilon = CalculateValueFromBits(epsilonBits);
        }

        private int CalculateValueFromBits(char[] bits)
        {
            int bitValue = 1;
            int value = 0;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '1') value += bitValue;
                bitValue = bitValue * 2;
            }
            return value;
        }

        private void CalculatePartTwo(string[] lines)
        {
            for (int i = 0; i<numLines; i++)
            {
                char[] chars = input[i];

                if (oxGenValueIsValid(chars)) oxGenRating =
                        CalculateValueFromBits(chars);
                if (co2ScrubValueIsValid(chars)) co2ScrubRating =
                        CalculateValueFromBits(chars);
            }
        }

        private bool oxGenValueIsValid(char[] chars)
        {
            bool valid = true;
            for (int i = 0; i<chars.Length && valid == true; i++)
            {
                if (!oxGenBitIsValid(chars, i)) valid = false;
            }
            return valid;
        }

        private bool co2ScrubValueIsValid(char[] chars)
        {
            bool valid = true;
            for (int i = 0; i < chars.Length && valid == true; i++)
            {
                if (!co2ScrubBitIsValid(chars, i)) valid = false;
            }
            return valid;
        }

        // oxGenRatings have a valid bit at position i if:
        // * the most common bit value for all lines in this position
        //   matches the value
        // * or, if this value has a 1 in the i position and the
        //   count is equal between 0 and 1
        private bool oxGenBitIsValid(char[] chars, int i)
        {
            return chars[i] == mostCommon[i] ||
                (chars[i] == '1' && mostCommon[i] == '?');
        }

        private bool co2ScrubBitIsValid(char[] chars, int i)
        {
            return chars[i] == leastCommon[i] ||
                (chars[i] == '0' && mostCommon[i] == '?');
        }
    }
}
