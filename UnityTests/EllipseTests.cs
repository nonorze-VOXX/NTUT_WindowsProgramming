using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Ellipse _ellipse;

        [TestInitialize()]
        public void SetUp()
        {
            _mockGraphics = new Mock<IGraphics>();
            _ellipse = new Ellipse(new Point(0, 0), new Point(10, 10), new Point(5, 5));
        }

        [TestMethod()]
        public void Draw_CallsDrawEllipseOnGraphics()
        {
            // Arrange
            var expectedPoint1 = new Point(0, 0);
            var expectedPoint2 = new Point(10, 10);

            // Act
            _ellipse.Draw(_mockGraphics.Object);

            // Assert
            _mockGraphics.Verify(g => g.DrawEllipse(expectedPoint1, expectedPoint2), Times.Once);
        }

        [TestMethod()]
        public void GetShapeName_ReturnsCorrectName()
        {
            // Act
            var name = _ellipse.GetShapeName();

            // Assert
            Assert.AreEqual("Ellipse", name);
        }
    }
}