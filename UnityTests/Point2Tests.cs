using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Tests
{
    [TestClass()]
    public class Point2Tests
    {
        const int ZERO = 0;
        const int TEN = 10;
        const int FIVE = 5;
        const int TWO = 2;
        Point2 point1;
        Point2 point2;
        [TestInitialize()]
        public void Initialize()
        {
            point1 = new Point2(ZERO, ZERO);
            point2 = new Point2(ZERO, ZERO);
        }
        [TestMethod()]
        public void Point2Test()
        {
            Assert.AreEqual(point1.X, ZERO);
            Assert.AreEqual(point1.Y, ZERO);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string result = "(0,0)";
            Assert.AreEqual(point1.ToString(), result);
        }

        [TestMethod()]
        public void GetTupleTest()
        {
            Tuple<float, float> tuple = point1.GetTuple();
            Assert.AreEqual(tuple.Item1, ZERO);
            Assert.AreEqual(tuple.Item2, ZERO);
        }


        [TestMethod()]
        public void GetSubstractTest()
        {
            point1.X = TEN;
            point1.Y = TEN;
            point2.X = FIVE;
            point2.Y = FIVE;
            Point2 result = Point2.GetSubstract(point1, point2);
            Assert.AreEqual(result.X, FIVE);
            Assert.AreEqual(result.Y, FIVE);
        }

        [TestMethod()]
        public void DivideTest()
        {
            point1.X = TEN;
            point1.Y = TEN;
            Point2 result = Point2.Divide(point1, FIVE);
            Assert.AreEqual(result.X, TWO);
            Assert.AreEqual(result.Y, TWO);
        }

        [TestMethod()]
        public void GetDistanceTest()
        {
            point1.X = TEN;
            point1.Y = TEN;
            point2.X = FIVE;
            point2.Y = FIVE;
            Point2 result = Point2.GetDistance(point1, point2);
            Assert.AreEqual(result.X, FIVE);
            Assert.AreEqual(result.Y, FIVE);
        }

        [TestMethod()]
        public void AddTest()
        {
            point1.X = FIVE;
            point1.Y = FIVE;
            point2.X = FIVE;
            point2.Y = FIVE;
            Point2 result = Point2.Add(point1, point2);
            Assert.AreEqual(result.X, TEN);
            Assert.AreEqual(result.Y, TEN);
        }


        [TestMethod()]
        public void IsBothPositiveTest()
        {
            point1.X = FIVE;
            point1.Y = FIVE;
            Assert.IsTrue(point1.IsBothPositive());
        }

        [TestMethod()]
        public void GetDistanceFloatTest()
        {
            point1.X = FIVE;
            point1.Y = FIVE;
            point2.X = FIVE;
            point2.Y = FIVE;
            float result = Point2.GetDistanceFloat(point1, point2);
            Assert.AreEqual(result, 0);
        }
    }
}