using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day19
{
    [TestClass]
    public class TestVector3
    {
        [TestMethod]
        public void TestConstructors()
        {
            var v1 = new Vector3(17, 23, 71);
            var v2 = new Vector3("17,23,71");

            Assert.AreEqual(v1, v2);

            Assert.AreEqual("  17,  23,  71", v1.ToString());
            var v3 = new Vector3(v1.ToString());

            Assert.AreEqual(v1, v3);
        }
    }
}
