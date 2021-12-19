using System;
using System.Collections.Generic;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input-example.txt";
            // string filename = "input.txt";
            var input = new PuzzleInput(filename);
            var calc = new Calculator();

            var scanners = input.Scanners;


            List<Vector3> points = new List<Vector3>()
            {
                new Vector3(-1, -1, 1),
                new Vector3(-2, -2, 2),
                new Vector3(-3, -3, 3),
                new Vector3(-2, -3, 1),
                new Vector3(5, 6, -4),
                new Vector3(8, 0, 7)
            };

            Console.WriteLine("-------------------------");

            foreach (Orientation o in Orientation.PossibleOrientations())
            {
                var rotatedPoints = calc.ApplyOrientation(o, points);
                DumpPoints(rotatedPoints);
                Console.WriteLine("-------------------------");
            }


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
