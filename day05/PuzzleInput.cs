using System;
using System.IO;
using System.Linq;

namespace day05
{
    public class PuzzleInput
    {
        public string[] Lines;

        public PuzzleInput(string filename)
        {
            ReadFile(filename);
        }

        private void ReadFile(string filename)
        {
            // more efficient to leave this as an enumerable
            // but changing to an array in case we need random
            // access to the lines as part of the puzzle
            Lines = File.ReadLines($"../../../{filename}").ToArray();
        }
    }
}
