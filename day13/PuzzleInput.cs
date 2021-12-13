using System;
using System.IO;

namespace day13
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
            Console.WriteLine($"Reading {fullpath}");
            Lines = File.ReadAllLines(fullpath);
        }
    }
}
