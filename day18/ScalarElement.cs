using System;
namespace day18
{
    public class ScalarElement : Element
    {
        public int Value;

        public static new ScalarElement Parse(string txt, int nest=0)
        {
            ScalarElement el = new ScalarElement();
            el.NestingLevel = nest;
            el.Value = int.Parse(txt);
            return el;
        }

        public ScalarElement()
        {
        }
    }
}
