using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        const int CANVAS_MAX = 500;
        /// <summary>
        /// test
        /// </summary>
        [TestMethod()]
        public void CreateByRandomTest()
        {
            var ellipse = ShapeFactory.CreateByRandom(ShapeType.Ellipse, CANVAS_MAX);
            Assert.AreEqual(ellipse.shape, "Ellipse");
        }

        /// <summary>
        /// rt
        /// </summary>
        [TestMethod()]
        public void CreateShapeTest()
        {
            Point2 point1 = new Point2(0, 0);
            Point2 point2 = new Point2(0, 0);
            var ellipse = ShapeFactory.CreateShape(ShapeType.Ellipse, point1, point2);
            Assert.AreEqual(ellipse.GetType().Name, ShapeType.Ellipse.ToString());
            var line = ShapeFactory.CreateShape(ShapeType.Line, point1, point2);
            Assert.AreEqual(line.GetType().Name, "Line");
            var rectangle = ShapeFactory.CreateShape(ShapeType.Rectangle, point1, point2);
            Assert.AreEqual(rectangle.GetType().Name, "Rectangle");
        }
    }
}