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
        Point2 point1;
        Point2 point2;
        const string name = "Rectangle";
        Rectangle rectangle;
        [TestInitialize()]
        public void Initialize()
        {
            point1 = new Point2(FIVE, FIVE);
            point2 = new Point2(ZERO, TEN);
            rectangle = new Rectangle(point1, point2);
        }
        [TestMethod()]
        public void RectangleTest()
        {
            Assert.AreEqual(rectangle.GetFirst(), point1);
            Assert.AreEqual(rectangle.GetSecond(), point2);
        }

        [TestMethod()]
        public void DrawTest()
        {
            var graphics = new Mock<IGraphics>();
            rectangle.Draw(graphics.Object);
            graphics.Verify(adapter => adapter.DrawRectangle(It.IsAny<Point2>(), It.IsAny<Point2>()), Times.Once());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(rectangle.GetShapeName(), name);
        }
    }
}