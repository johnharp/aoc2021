using System;
namespace day18
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public Element Add(Element a, Element b)
        {
            Element sum = new Element();
            sum.IsPair = true;

            sum.Left = a;
            sum.Right = b;

            return sum;
        }

        public Element FindFirstPairToExplode(Element s)
        {
            if (s.IsScalar) return null;

            if (s.IsPair)
            {
                if (s.NestedLevel < 4)
                {
                    Element a = FindFirstPairToExplode(s.Left);
                    if (a != null) return a;

                    Element b = FindFirstPairToExplode(s.Right);
                    if (b != null) return b;
                }

                if (s.NestedLevel == 4)
                {
                    return s;
                }
            }

            // if not a pair, if lower than level 4, or otherwise
            // can't find a candidate
            return null;
        }
    }
}
