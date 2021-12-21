using System;
namespace day21
{
    public static class State
    {
        // player#|p1pos,p1score|p2pos,p2score
        public static (int, int, int, int, int) Move(
            int n,
            (int, int, int, int, int) state)
        {
            int playerNum,
                p1pos,
                p1score,
                p2pos,
                p2score;

            (playerNum, p1pos, p1score, p2pos, p2score) = state;
            int pos = playerNum == 1 ? p1pos : p2pos;
            pos += n;
            while (pos > 10)
            {
                pos -= 10;
            }

            // score the player (and advance the proper one)
            if (playerNum == 1)
            {
                p1score += pos;
                p1pos = pos;
            }
            else
            {
                p2score += pos;
                p2pos = pos;
            }

            // advance to next player
            playerNum = playerNum == 1 ? 2 : 1;

            return (playerNum, p1pos, p1score, p2pos, p2score);
        }


    }
}
