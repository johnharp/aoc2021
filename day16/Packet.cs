using System;
using System.Text;

namespace day16
{
    public class Packet
    {
        public long Version;
        public long TypeId;
        public long LiteralValue;

        public string ContentBits;  // All content bits after the version
                                    // and type have been removed

        public string Remainder;    // All bits left over after parsing

        public Packet(string hex)
        {
            var b = new Bits();
            string binary = b.HexToBinary(hex);
            if (binary.Length < 6) throw new Exception("Invalid packet -- missing version and type ID");

            Version = b.BinaryToDecimal(binary.Substring(0, 3));
            TypeId = b.BinaryToDecimal(binary.Substring(3, 3));

            ContentBits = binary.Substring(6);
            Remainder = binary.Substring(6);
            
            if (TypeId == 4)
            {
                // Literal Value Packet
                ParseLiteral();
            }
            else
            {
                // Operator Packet
            }
        }

        // Given the r
        private void ParseLiteral()
        {
            var b = new Bits();
            var sb = new StringBuilder();

            int i = 0;
            bool handledLastGroup = false;

            while ((i<Remainder.Length) && (!handledLastGroup))
            {
                char groupEndBit = Remainder[i];
                if (groupEndBit == '0') handledLastGroup = true;

                sb.Append(Remainder.Substring(i + 1, 4));
                i += 5;
            }

            Remainder = Remainder.Substring(i);
            LiteralValue = b.BinaryToDecimal(sb.ToString()); 
        }
    }
}
