using System;
using System.IO;
using System.Linq;

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
            var lines = File.ReadLines(filename);

            return lines.ToArray();
        }
    }
}
