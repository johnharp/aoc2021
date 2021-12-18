using System;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new PuzzleInput("input.txt");
            var calc = new Calculator();

            Element sum = Element.CreateElementFromString(input.Lines[0]);

            for (int i = 1; i<input.Lines.Length; i++)
            {
                Element a = Element.CreateElementFromString(input.Lines[i]);

                sum = calc.Add(sum, a);
                calc.Reduce(sum);
                Console.WriteLine(sum);
            }

            Console.Write("Magnitude: ");
            Console.Write(sum.Magnitude());
            Console.WriteLine();
        }
    }
}
