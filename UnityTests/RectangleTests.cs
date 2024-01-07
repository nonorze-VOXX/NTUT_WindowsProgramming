using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass]
    public class RectangleTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Rectangle _rectangle;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _mockGraphics = new Mock<IGraphics>();
            _rectangle = new Rectangle(new Point(0, 0), new Point(10, 10), new Point(5, 5));
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_CallsDrawRectangleOnGraphics()
        {
            // Arrange
            var expectedStartPoint = new Point(0, 0);
            var expectedEndPoint = new Point(10, 10);

            // Act
            _rectangle.Draw(_mockGraphics.Object);

            // Assert
            _mockGraphics.Verify(g => g.DrawRectangle(expectedStartPoint, expectedEndPoint), Times.Once);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void GetShapeName_ReturnsRectangle()
        {
            // Act
            var result = _rectangle.GetShapeName();

            // Assert
            Assert.AreEqual("Rectangle", result);
        }
    }
}