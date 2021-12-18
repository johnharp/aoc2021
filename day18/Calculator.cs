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
    }
}
