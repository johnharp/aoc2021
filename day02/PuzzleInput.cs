using System;
using System.IO;

namespace day02
{
    public class PuzzleInput
    {
        public string[] Example()
        {
            return ReadInputFile("../../../example-input.txt");
        }

        public string[] PartA()
        {
            return ReadInputFile("../../../parta-input.txt");
        }


        private string[] ReadInputFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            return lines;
        }
    }
}
