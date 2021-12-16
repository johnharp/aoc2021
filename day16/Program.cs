using System;

namespace day16
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            var input = new PuzzleInput(filename);

            Packet p = Packet.PacketFromHex(input.Lines[0]);
            Console.Write($"Version sum = {p.VersionSum}");

        }
    }
}
