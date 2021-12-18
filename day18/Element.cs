using System;
namespace day18
{
    public class Element
    {
        public int NestingLevel
        {
            get
            {
                return _NestingLevel;
            }
            set
            {
                _NestingLevel = value;
                if (IsPair)
                {
                    LeftElement.NestingLevel = value + 1;
                    RightElement.NestingLevel = value + 1;
                }
            }
        }
        private int _NestingLevel;


        public bool IsPair
        {
            get { return this.GetType() == typeof(PairElement); }
        }

        public bool IsScalar
        {
            get { return this.GetType() == typeof(ScalarElement); }
        }

        public Element Parent
        {
            get { return _Parent; }
            set
            {
                _Parent = value;
                NestingLevel = _Parent.NestingLevel + 1;
            }
        }

        private Element _Parent = null;

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
