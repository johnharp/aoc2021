using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day04
{
    public class PuzzleInput
    {
        public List<String> ExampleInput()
        {
            return ReadInputFile("../../../input-example.txt");
        }

        public List<String> Input()
        {
            return ReadInputFile("../../../input.txt");
        }


        private List<String> ReadInputFile(string filename)
        {
            var lines = File.ReadLines(filename);

            return lines.ToList();
        }
    }
}
