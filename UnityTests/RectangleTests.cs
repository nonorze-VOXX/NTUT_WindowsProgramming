using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        const int ZERO = 0;
        const int TEN = 10;
        const int FIVE = 5;
        const int TWO = 2;
        PointFunction point1;
        PointFunction point2;
        const string name = "Rectangle";
        Rectangle rectangle;
        /// <summary>
        /// t
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            point1 = new Point2(FIVE, FIVE);
            point2 = new Point2(ZERO, TEN);
            rectangle = new Rectangle(point1, point2);
        }

        /// <summary>
        /// t
        /// </summary>
        [TestMethod()]
        public void RectangleTest()
        {
            Assert.AreEqual(rectangle.GetFirst(), point1);
            Assert.AreEqual(rectangle.GetSecond(), point2);
        }

        /// <summary>
        /// t
        /// </summary>
        [TestMethod()]
        public void DrawTest()
        {
            var graphics = new Mock<IGraphics>();
            rectangle.Draw(graphics.Object);
            graphics.Verify(adapter => adapter.DrawRectangle(It.IsAny<PointFunction>(), It.IsAny<PointFunction>()), Times.Once());
        }

        /// <summary>
        /// t
        /// </summary>
        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(rectangle.GetShapeName(), name);
        }
    }
}