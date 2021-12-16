using System;
namespace day16
{
    public class Packet
    {
        public long Version;
        public long TypeId;

        public Packet(string hex)
        {
            var b = new Bits();
            string binary = b.HexToBinary(hex);
            if (binary.Length < 6) throw new Exception("Invalid packet -- missing version and type ID");

            Version = b.BinaryToDecimal(binary.Substring(0, 3));
            TypeId = b.BinaryToDecimal(binary.Substring(3, 3));

            string remainder = binary.Substring(6);
        }
    }
}
