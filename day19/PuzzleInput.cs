using System;
using System.Collections.Generic;
using System.IO;

namespace day19
{
    public class PuzzleInput
    {
        public List<Scanner> Scanners = new List<Scanner>();

        public PuzzleInput(string filename)
        {
            ReadInputFile($"../../../{filename}");
        }

        public void ReadInputFile(string fullpath)
        {
            var lines = File.ReadLines(fullpath);
            Scanner s = null;

            foreach(var line in lines)
            {
                if (line.Contains("-- scanner "))
                {
                    string str = line.Replace("---", "")
                        .Replace("scanner", "")
                        .Trim();
                    int id = int.Parse(str);
                    s = new Scanner();
                    s.Id = id;

                    Scanners.Add(s);
                }
                else if (string.IsNullOrEmpty(line))
                {
                    // no-op, this is just
                    // a spacer line in the puzzle input
                }
                else
                {
                    var point = new Vector3(line);
                    s.Points.Add(point);
                }

            }
        }
    }
}
