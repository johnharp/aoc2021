using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day06
{
    public class PuzzleInput
    {
        public List<String> Lines;

        public PuzzleInput(string filename)
        {
            ReadInputFile($"../../../{filename}");
        }

        private void ReadInputFile(string filename)
        {
            Lines = File.ReadLines(filename).ToList();
        }
    }
}
