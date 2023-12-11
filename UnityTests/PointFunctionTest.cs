using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass()]
    public class PointFunctionTests
    {
        [TestMethod()]
        public void GetSubstract_ReturnsCorrectResult()
        {
            var result = PointFunction.GetSubstract(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(new Point(5, 5), result);
        }

        [TestMethod()]
        public void Divide_ReturnsCorrectResult()
        {
            var result = PointFunction.Divide(new Point(10, 10), 2);
            Assert.AreEqual(new Point(5, 5), result);
        }

        [TestMethod()]
        public void GetDistance_ReturnsCorrectResult()
        {
            var result = PointFunction.GetDistance(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(new Point(5, 5), result);
        }

        [TestMethod()]
        public void GetDistanceFloat_ReturnsCorrectResult()
        {
            var result = PointFunction.GetDistanceFloat(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(7.0710678f, result, 0.0000001f);
        }

        [TestMethod()]
        public void Add_ReturnsCorrectResult()
        {
            var result = PointFunction.Add(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(new Point(15, 15), result);
        }

        [TestMethod()]
        public void AddY_ReturnsCorrectResult()
        {
            var result = PointFunction.AddY(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(new Point(10, 15), result);
        }

        [TestMethod()]
        public void AddX_ReturnsCorrectResult()
        {
            var result = PointFunction.AddX(new Point(10, 10), new Point(5, 5));
            Assert.AreEqual(new Point(15, 10), result);
        }

        [TestMethod()]
        public void IsBothNotNegative_ReturnsCorrectResult()
        {
            var result = PointFunction.IsBothNotNegative(new Point(10, 10));
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsBothNotNegative_ReturnsFalseWhenNegative()
        {
            var result = PointFunction.IsBothNotNegative(new Point(-10, 10));
            Assert.IsFalse(result);
        }
    }
}