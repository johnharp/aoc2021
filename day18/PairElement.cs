using System;
namespace day18
{
    public class PairElement : Element
    {
        public Element LeftElement;
        public Element RightElement;

        public static new PairElement Parse(string txt, int nest=0)
        {
            PairElement el = new PairElement();
            el.NestingLevel = nest;

            if (txt[0] != '[' ||
                txt[txt.Length-1] != ']')
            {
                throw new Exception($"Invalid pair element text: {txt}");
            }

            txt = txt.Substring(1, txt.Length - 2);
            int splitindex = -1;
            int braces = 0;
            for (int i = 0; i<txt.Length; i++)
            {
                char c = txt[i];
                if (c == '[') braces++;
                else if (c == ']') braces--;
                else if (c == ',' && braces == 0)
                {
                    splitindex = i;
                    break;
                }
            }

            if (splitindex == -1)
                throw new Exception($"Invalid pair text, can't find split index: {txt}");

            string lefttxt = txt.Substring(0, splitindex);
            string righttext = txt.Substring(splitindex + 1);


            el.LeftElement = Element.Parse(lefttxt, nest + 1);
            el.RightElement = Element.Parse(righttext, nest + 1);

            return el;
        }

        public PairElement()
        {
        }
    }
}
