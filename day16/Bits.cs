using System;
using System.Text;
using System.Collections.Generic;

namespace day16
{
    public class Bits
    {

        public string HexToBinary(string hex)
        {
            var sb = new StringBuilder();
            foreach (var hexchar in hex.ToCharArray())
            {
                sb.Append(HexDigitToBinary(hexchar));
            }

            return sb.ToString();
        }

        public string HexDigitToBinary(char hexchar)
        {
            string binary = "";
            string hexdigit = new string(hexchar, 1);
            int intValue = Convert.ToInt32(hexdigit, 16);

            binary = Convert.ToString(intValue, 2);
            binary = binary.PadLeft(4, '0');
            return binary;
        }

        public Bits()
        {
        }
    }
}
