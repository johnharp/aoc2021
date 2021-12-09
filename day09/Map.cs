using System;
namespace day09
{
    public class Map
    {
        public long[][] v;
        public long Width;
        public long Height;

        public Map(string[] lines)
        {
            string firstLine = lines[0].Trim();

            Width = firstLine.Length;
            Height = lines.Length;

            // map values are arranged in v[row][col]
            v = new long[Height][];


            for (int row = 0; row<lines.Length; row++)
            {
                string line = lines[row].Trim();
                v[row] = new long[Width];

                int col = 0;
                foreach(char c in line)
                {
                    long value = long.Parse(new String(c, 1));
                    v[row][col] = value;

                    col++;
                }
            }

        }

        public long SumRiskLevels()
        {
            long sum = 0;

            for(int row = 0; row < Height; row++)
            {
                for (int col=0; col<Width; col++)
                {
                    sum += RiskLevelOfPoint(row, col);
                }
            }

            return sum;
        }

        private long RiskLevelOfPoint(int row, int col)
        {
            long value = v[row][col];
            long riskLevel = 0;

            if ((row == 0 || v[row - 1][col] > value) &&
                (col == Width - 1 || v[row][col + 1] > value) &&
                (row == Height - 1 || v[row + 1][col] > value) &&
                (col == 0 || v[row][col - 1] > value))
            {
                riskLevel = value + 1;
            }

            return riskLevel;
        }

        public void Dump()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    long value = v[row][col];
                    Console.Out.Write(value);
                }
                Console.Out.WriteLine();
            }
        }
    }
}
