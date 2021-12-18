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

        // returns true if able to explode an element
        // false, if none explode
        public bool Explode(Element root)
        {
            bool didExplode = false;
            Element e = FindFirstPairToExplode(root);

            if (e != null)
            {
                didExplode = true;
                AddToFirstNumberLeftOf(e, e.Left.Value);
            }

            return didExplode;
        }

        public void AddToFirstNumberLeftOf(Element pair, int value)
        {
            // move up the tree until we reach a pair
            // where we came in via the right-hand branch,
            // or we reach the root and can't go any further
            if (pair.Parent == null) return;

            Element p = pair;
            Element foundparent = null;
            while (p.Parent != null)
            {
                if (p.Parent.Right == p)
                {
                    // found a parent where we came in via the right
                    // branch
                    foundparent = p.Parent;
                    break;
                }
                else
                {
                    p = p.Parent;
                }
            }

            // now traverse down the left hand side until
            // we find a right hand scalar
            if (foundparent != null)
            {
                p = foundparent;
                while (p.Left.IsPair)
                {
                    p = p.Left;
                }

                if (p.Left.IsScalar) p.Left.Value += value;
            }
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

                // for a pair to explode it must be at level
                // 4 nesting and contains two scalars
                if (s.NestedLevel == 4 &&
                    s.Left.IsScalar &&
                    s.Right.IsScalar)
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
