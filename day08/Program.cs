using System;
using System.Linq;
using System.Collections.Generic;

namespace day08
{
    class Program
    {
        private static string[] ALLSIGNALS = { "a", "b", "c", "d", "e", "f", "g" };
        private static string ALLSEGMENTS = "abcdefg";

        static void Main(string[] args)
        {
            PuzzleInput input = new PuzzleInput("input-example.txt");

            Part1(input);
            Part2(input);
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

        private static void Part2(PuzzleInput input)
        {
            Console.Out.WriteLine("Part 2 -");
            foreach (var line in input.Lines)
            {
                string[] patterns;
                string[] outputs;

                (patterns, outputs) = SplitLine(line);
                Part2Line(patterns, outputs);
            }
        }

        private static void Part2Line(string[] patterns, string[] outputs)
        {
            // facts dictionary has:
            //   key = a signal letter (a, b, c, d, e, f, or g)
            //   value = a string listing all the possible segments that
            //           signal could drive.  If we know nothing it would
            //           be like this "abcdefg".  If we know the exact mapping
            //           it would have a single segment letter, ex. "b"
            Dictionary<string, string> facts = InitialFacts();

            WriteLine(patterns, outputs);

            string signalsForOne = FindPatternOfLength(2, patterns);
            OnlyTheseSignalsCouldBeTheseSegments(signalsForOne, "cf", facts);

            string signalsForSeven = FindPatternOfLength(3, patterns);
            OnlyTheseSignalsCouldBeTheseSegments(signalsForSeven, "acf", facts);

            string signalsForFour = FindPatternOfLength(4, patterns);
            OnlyTheseSignalsCouldBeTheseSegments(signalsForFour, "bcdf", facts);

            //ApplyRuleFor1(patterns, facts);
            //ApplyRuleFor7(patterns, facts);
            //ApplyRuleFor1And7(patterns, facts);
            WriteFacts(facts);

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

        private static void WriteLine(string[] patterns, string[] outputs)
        {
            foreach (string pattern in patterns)
            {
                Console.Out.Write(pattern + " ");
            }
            Console.Out.Write("===> ");
            foreach (string output in outputs)
            {
                Console.Out.Write(output + " ");
            }
            Console.Out.WriteLine();
        }

        private static string Subtract(string s1, string remove)
        {
            string v = "";

            foreach(var c in s1)
            {
                if (!remove.Contains(c))
                {
                    v += c;
                }
            }

            return v;
        }

        private static string Intersect(string s1, string s2)
        {
            string v = "";

            foreach(var c in s1)
            {
                if (s2.Contains(c))
                {
                    v += c;
                }
            }

            foreach(var c in s2)
            {
                if (s1.Contains(c) && !v.Contains(c))
                {
                    v += c;
                }
            }

            return v;
        }

        private static string Difference(string s1, string s2)
        {
            string v = "";

            foreach (var c in s1)
            {
                if (!s2.Contains(c))
                {
                    v += c;
                }
            }

            foreach (var c in s2)
            {
                if (!s1.Contains(c))
                {
                    v += c;
                }
            }

            return v;
        }

        private static void OnlyTheseSignalsCouldBeTheseSegments(string signals, string segments, Dictionary<string, string> facts)
        {
            foreach (string key in ALLSIGNALS)
            {
                if (signals.Contains(key))
                {
                    facts[key] = Intersect(facts[key], segments);
                }
                else
                {
                    facts[key] = Subtract(facts[key], segments);
                }
            }
            CheckForOneLeft(facts);
        }

        private static void CheckForOneLeft(Dictionary<string, string> facts)
        {
            foreach (string key1 in ALLSIGNALS)
            {
                if (facts[key1].Length == 1)
                {
                    foreach (string key2 in ALLSIGNALS)
                    {
                        if (key2 != key1) facts[key2] = Subtract(facts[key2], facts[key1]);
                    }
                }
            }
        }

        private static void ApplyRuleFor1And7(string[] patterns, Dictionary<string, string> facts)
        {
            // find the patterns of length 2 (this will display "1") and length
            // 3 (this will display "7")
            string patternFor1 = FindPatternOfLength(2, patterns);
            string patternFor7 = FindPatternOfLength(3, patterns);
            string segmentASignal = Difference(patternFor1, patternFor7);
            SolveASignal(segmentASignal, "a", facts);
        }

        private static string FindPatternOfLength(int l, string[] patterns)
        {
            foreach(var pattern in patterns)
            {
                if (pattern.Length == l) return pattern;
            }

            throw new Exception($"Error: didn't find a pattern of length {l}.  This shouldn't happen."); ;
        }

        private static void SolveASignal(string sig, string seg, Dictionary<string, string> facts)
        {
            // We've discovered that signal letter "sig" represents the segment
            // letter "seg".

            facts[sig] = seg;

            // This also means seg can be removed from the possible facts for all other
            // signals
            string[] keys = facts.Keys.ToArray();
            foreach(string key in keys)
            {
                // for each fact that is not about this solved signal
                if (key != sig)
                {
                    facts[key] = facts[key].Replace(seg, "");
                }
            }
        }

        private static void WriteFacts(Dictionary<string, string> facts)
        {
            foreach(string key in facts.Keys)
            {
                Console.Out.WriteLine($"\t{key} could be \"{facts[key]}\"");
            }
        }
        private static Dictionary<string, string> InitialFacts()
        {
            var facts = new Dictionary<string, string>();

            // initially we know nothing
            // each of the signal names could be driving any
            // of the segments
            string[] signalNames = "abcdefg"
                .Select(x => new String(x, 1)).ToArray();
            foreach(string signalName in signalNames)
            {
                facts[signalName] = "abcdefg";
            }
            return facts;
        }
    }
}
