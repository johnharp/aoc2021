using System;
using System.Collections.Generic;

namespace day07
{
    public class Tally
    {
        public long[] CountLeftOf;
        public long[] CountAt;
        public long[] CountRightOf;

        public long TotalCount;
        public long MaxValue;

        public long FuelUsageAtZero;
        
        public Tally(List<string> input)
        {
            if (input.Count != 1)
            {
                throw new Exception("Invalid input -- expecting exactly one line.");
            }

            string[] strValues = input[0].Split(",");
            TotalCount = strValues.Length;
            int[] intValues = new int[TotalCount];

            for(int i = 0; i<intValues.Length; i++)
            {
                string strValue = strValues[i];
                int value = int.Parse(strValue);
                intValues[i] = value;
                if (value > MaxValue) MaxValue = value;
            }

            CountAt = new long[MaxValue + 1];
            CountLeftOf = new long[MaxValue + 1];
            CountRightOf = new long[MaxValue + 1];

            for (int i = 0; i < intValues.Length; i++)
            {
                int value = intValues[i];
                CountAt[value]++;
            }

            for (int i = 0; i<=MaxValue; i++)
            {
                for (int j = 0; j<i; j++)
                {
                    CountLeftOf[i] += CountAt[j];
                }

                for (int j = i+1; j<=MaxValue; j++)
                {
                    CountRightOf[i] += CountAt[j];
                }
            }


            for (int i = 1; i<=MaxValue; i++)
            {
                FuelUsageAtZero += CountAt[i] * i;
            }
        }

        public void Dump()
        {
            long usage = FuelUsageAtZero;

            for (int i = 0; i <= MaxValue; i++)
            {
                Console.Out.WriteLine(
                    $"{i}: {CountLeftOf[i]}   {CountAt[i]}   {CountRightOf[i]}  =>   {usage}");

                long u2 = usage;
                // moving one position to the right, so the current
                // position will now cost one fuel
                usage += CountAt[i] + CountLeftOf[i] - CountRightOf[i];

                if (usage > u2) break;
            }
        }
    }
}
