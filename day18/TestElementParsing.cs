using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day18
{
    [TestClass]
    public class TestElementParsing
    {
        [TestMethod]
        public void Test1()
        {
            var el = Element.Parse("[[1,2],3]");
            Assert.IsInstanceOfType(el, typeof(PairElement));
            Assert.IsInstanceOfType(el.LeftElement, typeof(PairElement));
            Assert.IsInstanceOfType(el.RightElement, typeof(ScalarElement));
            Assert.AreEqual(3, el.RightElement.Value);
            Assert.AreEqual(1, el.LeftElement.LeftElement.Value);
            Assert.AreEqual(2, el.LeftElement.RightElement.Value);
        }
    }
}
