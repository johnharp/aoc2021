using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day16
{
    [TestClass]
    public class TestPacket
    {
        [TestMethod]
        public void TestVersionAndTypeIdParsing()
        {
            var p1 = new Packet("D2FE28");
            Assert.AreEqual(6, p1.Version);
            Assert.AreEqual(4, p1.TypeId);

            var p2 = new Packet("EE00D40C823060");
            Assert.AreEqual(7, p2.Version);
            Assert.AreEqual(3, p2.TypeId);

        }
    }
}
