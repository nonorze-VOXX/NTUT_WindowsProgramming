using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.Tests
{
    [TestClass()]
    public class LineTests
    {
        const int ZERO = 0;
        const int TEN = 10;
        const int FIVE = 5;
        const int TWO = 2;
        Point2 point1;
        Point2 point2;
        const string name = "Line";
        Line line;
        [TestInitialize()]
        public void Initialize()
        {
            point1 = new Point2(FIVE, FIVE);
            point2 = new Point2(ZERO, TEN);
            line = new Line(point1, point2);
        }
        [TestMethod()]
        public void LineTest()
        {
            Assert.AreEqual(line.GetFirst(), point1);
            Assert.AreEqual(line.GetSecond(), point2);
        }

        [TestMethod()]
        public void DrawTest()
        {
            var graphics = new Mock<IGraphics>();
            line.Draw(graphics.Object);
            graphics.Verify(adapter => adapter.DrawLine(It.IsAny<Point2>(), It.IsAny<Point2>()), Times.Once());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(line.GetShapeName(), name);
        }
    }
}