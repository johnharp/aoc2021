using System;
using System.IO;

namespace day20
{
    public class PuzzleInput
    {
        public String[] Lines;

        public PuzzleInput(string filename)
        {
            ReadInputFile($"../../../{filename}");
        }

        public void ReadInputFile(string fullpath)
        {
            Lines = File.ReadAllLines("fullpath");
        }
    }
}
