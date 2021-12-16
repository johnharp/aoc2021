using System;
using System.Collections.Generic;

namespace day15_dijkstra
{
    public class Node
    {
        public static Dictionary<string, Node> NodeIndex = new Dictionary<string, Node>();
        public static int NumCols;
        public static int NumRows;

        public static Node Get(int c, int r)
        {
            return NodeIndex[$"N({c},{r})"];
        }

        public int Col;
        public int Row;

        public int Risk;
        public int RiskSum;

        public bool IsFinal;

        public string Label
        {
            get
            {
                return $"N({Col},{Row})";
            }
        }

        public Node(int c, int r, int risk)
        {
            Col = c;
            Row = r;
            Risk = risk;

            // Upper left node is the starting point and
            // has a 0 sum.
            RiskSum = c == 0 && r == 0 ? 0 : int.MaxValue;

            IsFinal = false;

            NodeIndex[Label] = this;
        }

        public List<Node> NonFinalNeighbors()
        {
            var nodes = new List<Node>();

            TryNeighbor(nodes, -1,  0);
            TryNeighbor(nodes,  0, -1);
            TryNeighbor(nodes, +1,  0);
            TryNeighbor(nodes,  0, +1);

            return nodes;
        }

        private void TryNeighbor(List<Node> nodes, int dc, int dr)
        {
            int c = Col + dc;
            int r = Row + dr;

            if (c >= 0 && r >= 0 &&
                c < NumCols && r < NumRows)
            {
                Node n = Get(c, r);
                if (!n.IsFinal) nodes.Add(n);
            }
        }
    }
}
