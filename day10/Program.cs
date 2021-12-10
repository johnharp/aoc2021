using System;
using System.Collections.Generic;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";

            PuzzleInput input = new PuzzleInput(filename);
            Part1(input);
        }

        static void Part1(PuzzleInput input)
        {
            long errorScore = 0;

            foreach (string line in input.Lines)
            {
                Stack<char> s = new Stack<char>();

                foreach(var c in line)
                {
                    if (IsOpeningBracket(c))
                    {
                        s.Push(c);
                    }
                    else if (IsClosingBracket(c))
                    {
                        char openingChar;
                        if (s.TryPop(out openingChar))
                        {
                            if (!IsMatch(openingChar, c))
                            {
                                // corrupted chunk
                                errorScore += ErrorScore(c);
                                continue;
                            }
                        }
                    }
                }
            }

            Console.Out.WriteLine($"Total error score = {errorScore}");
        }

        static bool IsOpeningBracket(char c)
        {
            return c == '(' || c == '[' || c == '{' || c == '<';
        }

        static bool IsClosingBracket(char c)
        {
            return c == ')' || c == ']' || c == '}' || c == '>';
        }

        static bool IsMatch(char openChar, char closeChar)
        {
            return
                (openChar == '(' && closeChar == ')') ||
                (openChar == '[' && closeChar == ']') ||
                (openChar == '{' && closeChar == '}') ||
                (openChar == '<' && closeChar == '>');
        }

        static int ErrorScore(char c)
        {
            int score = 0;

            if (c == ')') score = 3;
            else if (c == ']') score = 57;
            else if (c == '}') score = 1197;
            else if (c == '>') score = 25137;

            return score;
        }
    }
}
