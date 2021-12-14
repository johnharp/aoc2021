﻿using System;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input-example.txt";
            //string filename = "input.txt";

            PuzzleInput input = new PuzzleInput(filename);
            ElementTracker tracker = new ElementTracker();

            tracker.InitializeRules(input.InsertionRules);
            tracker.InitializeElements(input.InitialElements);
            Part1(tracker);

 
        }

        public static void Part1(ElementTracker tracker)
        {
            for(int i = 1; i<=10; i++)
            {
                tracker.ApplyRulesToElements();
                Console.WriteLine($"After iteration {i}");
            }
            tracker.DumpStatistics();
        }

        public static void Part2(ElementTracker tracker)
        {

        }
    }
}
