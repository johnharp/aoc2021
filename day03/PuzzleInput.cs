using System;
using System.IO;
using System.Linq;

namespace day03
{
    public class PuzzleInput
    {
        public string[] Example()
        {
            return ReadInputFile("../../../input-example.txt");
        }

        public string[] PartA()
        {
            return ReadInputFile("../../../input.txt");
        }


        private string[] ReadInputFile(string filename)
        {
            var lines = File.ReadLines(filename);

            return lines.ToArray();
        }
    }
}
