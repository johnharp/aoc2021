using System;
using System.Collections.Generic;
using System.Linq;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filename = "input-example.txt";
            string filename = "input.txt";
            var input = new PuzzleInput(filename);
            var calc = new Calculator();

            var scanners = input.Scanners;


            var matches = calc.LookForMatches(scanners[0], scanners[8]);
            DumpPoints(matches);
            Console.Out.WriteLine("stop");

        }

        public static void DumpPoints(List<Vector3> points)
        {
            foreach (var p in points)
            {
                Console.WriteLine(p);
            }
        }
    }


}
