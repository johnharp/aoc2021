using System;
namespace day15
{
    public class Map
    {
        // Values[col][row]
        public long[][] Values;
        public long NumCols;
        public long NumRows;

        public Map(string[] initialValues)
        {
            NumRows = initialValues.Length;
            NumCols = initialValues[0].Length;

            Values = new long[NumCols][];
            for (long col=0; col<NumCols; col++)
            {
                Values[col] = new long[NumRows];
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
    }
}
