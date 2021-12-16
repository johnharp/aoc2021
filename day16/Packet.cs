using System;
using System.Collections.Generic;
using System.Text;

namespace day16
{
    public class Packet
    {
        public long Version;
        public long TypeId;
        public long LiteralValue;

        public char SubPacketsLengthType = ' ';

        public List<Packet> Packets = new List<Packet>();
        public long NumSubPackets;
        public long SubPacketDataLength;


        public string ContentBits;  // All content bits after the version
                                    // and type have been removed

        public string Remainder;    // All bits left over after parsing

        public Packet(string binary)
        {
            var b = new Bits();
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
                ParseOperator();
            }
        }

        public static Packet PacketFromHex(string hex)
        {
            var b = new Bits();
            string binary = b.HexToBinary(hex);
            return new Packet(binary);
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
            ContentBits = ContentBits.Substring(0, i);

            LiteralValue = b.BinaryToDecimal(sb.ToString()); 
        }

        private void ParseOperator()
        {
            Bits b = new Bits();
            SubPacketsLengthType = Remainder[0];
            Remainder = Remainder.Substring(1);

            if (SubPacketsLengthType == '0')
            {
                string subpacketsNumBits = Remainder.Substring(0, 15);
                SubPacketDataLength = b.BinaryToDecimal(subpacketsNumBits);
                Remainder = Remainder.Substring(15);


            }
            else if (SubPacketsLengthType == '1')
            {
                string numSubPacketsBits = Remainder.Substring(0, 11);
                NumSubPackets = b.BinaryToDecimal(numSubPacketsBits);
                Remainder = Remainder.Substring(11);

                for (int n = 0; n<NumSubPackets; n++)
                {
                    Packet p = new Packet(Remainder);
                    Remainder = p.Remainder;
                    Packets.Add(p);
                }
            }
            else
            {
                throw new Exception($"Invalid packet length type: {SubPacketsLengthType}");
            }
        }
    }
}
