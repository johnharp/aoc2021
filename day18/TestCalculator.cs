using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace day18
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator c = new Calculator();

            Element a = Element.CreateElementFromString("[1,2]");
            Element b = Element.CreateElementFromString("[[3,4],5]");

            // sum should be [[1,2],[[3,4],5]]

            Element s = c.Add(a, b);

            Assert.IsTrue(s.IsPair);
            Assert.IsFalse(s.IsScalar);
            Assert.AreEqual(0, s.NestedLevel);

            Element t1 = s.Left;
            Assert.IsTrue(t1.IsPair);
            Assert.IsFalse(t1.IsScalar);
            Assert.AreEqual(1, t1.NestedLevel);
            Assert.AreEqual(s, t1.Parent);

            Element t2 = s.Left.Left;
            Assert.IsTrue(t2.IsScalar);
            Assert.IsFalse(t2.IsPair);
            Assert.AreEqual(1, t2.Value);
            Assert.AreEqual(2, t2.NestedLevel);
            Assert.AreEqual(t1, t2.Parent);

            Element t3 = s.Left.Right;
            Assert.IsTrue(t3.IsScalar);
            Assert.IsFalse(t3.IsPair);
            Assert.AreEqual(2, t3.Value);
            Assert.AreEqual(2, t3.NestedLevel);
            Assert.AreEqual(t1, t3.Parent);

            Element t4 = s.Right.Left;
            Assert.IsTrue(t4.IsPair);
            Assert.IsFalse(t4.IsScalar);
            Assert.AreEqual(2, t4.NestedLevel);
            Assert.AreEqual(s.Right, t4.Parent);

            Assert.AreEqual(3, s.Right.Left.Left.Value);
            Assert.AreEqual(4, s.Right.Left.Right.Value);
            Assert.AreEqual(5, s.Right.Right.Value);

        }
    }
}
