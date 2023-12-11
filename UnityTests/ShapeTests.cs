using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Tests
{
    class TestShape : Shape
    {
        public TestShape(PointFunction first, PointFunction second) : base(first, second)
        {

        }
        /// <summary>
        /// set
        /// </summary>
        public override void Draw(IGraphics graphics)
        {
        }

        /// <summary>
        /// set
        /// </summary>
        public override string GetShapeName()
        {
            return "";
        }
    }
    /// <summary>
    /// set
    /// </summary>
    [TestClass()]
    public class ShapeTests
    {
        const float HALF = 0.5f;
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void IsPointInTest()
        {
            PointFunction point1 = new Point2(1, 1);
            PointFunction point2 = new Point2(0, 0);
            PointFunction point3 = new Point2(HALF, HALF);
            var shape = new TestShape(point1, point2);
            shape.Draw(null);
            Assert.IsTrue(shape.IsPointIn(point3));
        }
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void GetInfomation()
        {
            PointFunction point1 = new Point2(0, 0);
            PointFunction point2 = new Point2(0, 0);
            var shape = new TestShape(point1, point2);
            Assert.AreEqual(shape.Information, point1.ToString() + ", " + point2.ToString());
        }
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void GetInfoStringTest()
        {
            PointFunction point1 = new Point2(0, 0);
            PointFunction point2 = new Point2(0, 0);
            var shape = new TestShape(point1, point2);
            Assert.AreEqual(shape.GetInfoString(), point1.ToString() + point2.ToString());
        }
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void GetShapeNameTest()
        {
            PointFunction point1 = new Point2(0, 0);
            PointFunction point2 = new Point2(0, 0);
            var shape = new TestShape(point1, point2);
            Assert.AreEqual(shape.shape, "");
        }
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void MoveTest()
        {
            PointFunction point1 = new Point2(1, 1);
            PointFunction point2 = new Point2(0, 0);
            PointFunction point3 = new Point2(HALF, HALF);
            var shape = new TestShape(point1, point2);
            shape.Move(point3);
            Assert.AreEqual(shape.GetFirst().X, PointFunction.Add(point1, point3).X);
            Assert.AreEqual(shape.GetFirst().Y, PointFunction.Add(point1, point3).Y);
            Assert.AreEqual(shape.GetSecond().X, PointFunction.Add(point2, point3).X);
            Assert.AreEqual(shape.GetSecond().Y, PointFunction.Add(point2, point3).Y);
        }


        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void SetFirstTest()
        {
            var point2 = new Point2(1, 1);
            var shape = new TestShape(new Point2(0, 0), new Point2(0, 0));
            shape.SetFirst(point2);
            Assert.AreEqual(shape.GetFirst(), point2);
            shape.SetSecond(point2);
            Assert.AreEqual(shape.GetSecond(), point2);
        }
    }
}