using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Unity.Command;

namespace Unity.Tests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        private CommandManager _commandManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _commandManager = new CommandManager();
        }

        [TestMethod()]
        public void CreateByRandom_ReturnsShape()
        {
            // Arrange
            var shapeType = ShapeType.Line;
            var randomMax = 100;
            var nowCanvas = new Point(0, 0);

            // Act
            var result = ShapeFactory.CreateByRandom(shapeType, randomMax, nowCanvas, _commandManager);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Line));
        }

        [TestMethod()]
        public void CreateShape_ReturnsLineWhenShapeTypeIsLine()
        {
            // Arrange
            var shapeType = ShapeType.Line;
            var start = new Point(0, 0);
            var end = new Point(10, 10);
            var nowCanvas = new Point(0, 0);

            // Act
            var result = ShapeFactory.CreateShape(shapeType, start, end, nowCanvas);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Line));
        }

        [TestMethod()]
        public void CreateShape_ReturnsRectangleWhenShapeTypeIsRectangle()
        {
            // Arrange
            var shapeType = ShapeType.Rectangle;
            var start = new Point(0, 0);
            var end = new Point(10, 10);
            var nowCanvas = new Point(0, 0);

            // Act
            var result = ShapeFactory.CreateShape(shapeType, start, end, nowCanvas);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Rectangle));
        }

        [TestMethod()]
        public void CreateShape_ReturnsEllipseWhenShapeTypeIsEllipse()
        {
            // Arrange
            var shapeType = ShapeType.Ellipse;
            var start = new Point(0, 0);
            var end = new Point(10, 10);
            var nowCanvas = new Point(0, 0);

            // Act
            var result = ShapeFactory.CreateShape(shapeType, start, end, nowCanvas);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Ellipse));
        }
    }
}