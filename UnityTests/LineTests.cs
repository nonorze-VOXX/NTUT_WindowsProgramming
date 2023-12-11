using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass]
    public class LineTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Line _line;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockGraphics = new Mock<IGraphics>();
            _line = new Line(new Point(0, 0), new Point(10, 10), new Point(5, 5));
        }

        [TestMethod()]
        public void Draw_CallsDrawLineOnGraphics()
        {
            // Arrange
            var expectedStartPoint = new Point(0, 0);
            var expectedEndPoint = new Point(10, 10);

            // Act
            _line.Draw(_mockGraphics.Object);

            // Assert
            _mockGraphics.Verify(g => g.DrawLine(expectedStartPoint, expectedEndPoint), Times.Once);
        }

        [TestMethod()]
        public void GetShapeName_ReturnsLine()
        {
            // Act
            var result = _line.GetShapeName();

            // Assert
            Assert.AreEqual("Line", result);
        }
    }
}