using System;
using System.Collections.Generic;

namespace day04
{
    public class Card
    {
        public string[][] values;
        public bool[][] marks;

        public Card(
            string l1,
            string l2,
            string l3,
            string l4,
            string l5
            )
        {
            values = new string[5][];
            values[0] = line(l1);
            values[1] = line(l2);
            values[2] = line(l3);
            values[3] = line(l4);
            values[4] = line(l5);

            marks = new bool[5][];
            for (int i = 0; i<5; i++)
            {
                marks[i] = new bool[5];
            }
        }

        public void MarkNumber(string num)
        {
            for (int r = 0; r<5; r++)
            {
                for (int c = 0; c<5; c++)
                {
                    if (values[r][c] == num)
                    {
                        marks[r][c] = true;
                    }
                }
            }
        }

        public bool IsWin()
        {
            bool win = false;
            // test rows
            for (int r = 0; r<5 && !win; r++)
            {
                for (int c = 0; c<5 && !win; c++)
                {
                    if (marks[r][c]) break;
                }
            }
        }

        private string[] line(string t)
        {
            string[] values = t.Split(" ",
                StringSplitOptions.RemoveEmptyEntries);
            return values;
        }
    }
}
