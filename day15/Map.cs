using System;
namespace day15
{
    public class Map
    {
        // Values[col][row]
        public long[][] Values;
        // LPS = Least Path Sum
        public long[][] LPS;


        public long NumCols;
        public long NumRows;

        public Map(string[] initialValues)
        {
            NumRows = initialValues.Length;
            NumCols = initialValues[0].Length;

            Values = new long[NumCols][];
            LPS = new long[NumCols][];

            for (long col=0; col<NumCols; col++)
            {
                Values[col] = new long[NumRows];
                LPS[col] = new long[NumRows];
            }

            for(long row = 0; row<NumRows; row++)
            {
                char[] colChars = initialValues[row].ToCharArray();
                for (long col = 0;  col < colChars.Length; col++)
                {
                    long value = long.Parse(new string(colChars[col], 1));

                    Values[col][row] = value;
                }
            }
        }

        public void ComputeLeastPathSums()
        {
            for (long row = NumRows - 1; row >= 0; row--)
            {
                for (long col = NumCols - 1; col >= 0; col--)
                {
                    long lps;

                    if (col == NumCols - 1 && row == NumRows - 1)
                    {
                        // we're at the goal
                        lps = 0;
                    }
                    else
                    {
                        long rightLps = col == NumCols - 1 ? long.MaxValue :
                            Values[col + 1][row] + LPS[col + 1][row];

                        long downLps = row == NumRows - 1 ? long.MaxValue :
                            Values[col][row + 1] + LPS[col][row + 1];

                        lps = Math.Min(rightLps, downLps);
                    }

                    LPS[col][row] = lps;
                }
            }
        }

        public void DumpLeastPathSums()
        {
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    Console.Write(LPS[col][row].ToString("D2"));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }
}
