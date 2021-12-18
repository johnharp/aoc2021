using System;
namespace day18
{
    public class Element
    {
        public int NestingLevel = 0;

        public Element LeftElement
        {
            get
            {
                return ((PairElement)this).LeftElement;
            }
        }

        public Element RightElement
        {
            get
            {
                return ((PairElement)this).RightElement;
            }
        }

        public int Value
        {
            get
            {
                return ((ScalarElement)this).Value;
            }
        }

        public static Element Parse(string txt, int nest=0)
        {
            if (txt[0] == '[')
            {
                return PairElement.Parse(txt, nest);
            }
            else if (Char.IsDigit(txt[0]) || txt[0] == '-')
            {
                return ScalarElement.Parse(txt, nest);
            }
            else
            {
                throw new Exception($"Invalid element text: {txt}");
            }
        }

        public Element()
        {
        }
    }
}
