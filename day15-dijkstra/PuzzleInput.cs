using System;
using System.IO;

namespace day15_dijkstra
{
    public class PuzzleInput
    {
        public string[] Lines;
        public int NumCols
        {
            get { return Lines[0].Length; }
        }

        public int NumRows
        {
            get { return Lines.Length; }
        }

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
