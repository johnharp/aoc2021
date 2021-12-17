using System;
using System.IO;

namespace day17
{
    public class PuzzleInput
    {
        string[] Lines;

        public PuzzleInput(string filename)
        {
            ReadInputFile($"../../../{filename}");
        }

        private void ReadInputFile(string fullpath)
        {
            Lines = File.ReadAllLines(fullpath);
        }
    }
}
