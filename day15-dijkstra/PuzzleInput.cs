using System;
using System.Collections.Generic;
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

        public void CreateNodes(int numTiles = 1)
        {
            Node.NodeIndex = new Dictionary<string, Node>();
            Node.NumCols = Lines[0].Length * numTiles;
            Node.NumRows = Lines.Length * numTiles;

            for (int rowtile = 0; rowtile < numTiles; rowtile++)
            {
                for (int coltile = 0; coltile < numTiles; coltile++)
                {
                    for (int row = 0; row < Lines.Length; row++)
                    {
                        for (int col = 0; col < Lines[0].Length; col++)
                        {
                            int value = int.Parse(new string(Lines[row][col], 1));

                            for (int i = 0; i < rowtile + coltile; i++)
                            {
                                value += 1;
                                if (value > 9) value = 1;
                            }

                            new Node(
                                col + (coltile * Lines[0].Length),
                                row + (rowtile * Lines.Length),
                                value);
                        }
                    }
                }
            }
        }

    }
}
