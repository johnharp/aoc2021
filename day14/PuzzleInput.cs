using System;
using System.IO;

namespace day14
{
    public class PuzzleInput
    {
        public string[] Lines;

        public PuzzleInput(string filename)
        {
            ReadInputFile($"../../../{filename}");
        }

        private void ReadInputFile(string fullpath)
        {
            Console.WriteLine($"Reading file {fullpath}");
            Lines = File.ReadAllLines(fullpath);
        }
    }
}
