using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        const int ZERO = 0;
        const int TEN = 10;
        const int FIVE = 5;
        const int TWO = 2;
        Point2 point1;
        Point2 point2;
        const string name = "Ellipse";
        Ellipse ellipse;
        [TestInitialize()]
        public void Initialize()
        {
            point1 = new Point2(FIVE, FIVE);
            point2 = new Point2(ZERO, TEN);
            ellipse = new Ellipse(point1, point2);
        }
        [TestMethod()]
        public void EllipseTest()
        {
            Assert.AreEqual(ellipse.GetFirst(), point1);
            Assert.AreEqual(ellipse.GetSecond(), point2);
        }

        [TestMethod()]
        public void DrawTest()
        {
            var graphics = new Mock<IGraphics>();
            ellipse.Draw(graphics.Object);
            graphics.Verify(adapter => adapter.DrawEllipse(It.IsAny<Point2>(), It.IsAny<Point2>()), Times.Once());
        }

        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual(ellipse.GetShapeName(), name);
        }
    }
}