using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass]
    public class ShapeTests
    {
        private MockShape _shape;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _shape = new MockShape(new Point(0, 0), new Point(10, 10), new Point(16000, 9000));
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void utils()
        {
            var s = _shape.shape;
            var str = _shape.Information;
            _shape.SetDrawCanvasSize(new Point(1, 1));
            _shape.SetFirst(new Point(1, 1));
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Move_ChangesShapePosition()
        {
            // Arrange
            var delta = new Point(5, 5);

            // Act
            _shape.Move(delta);

            // Assert
            Assert.AreEqual(new Point(5, 5), _shape.GetFirst());
            Assert.AreEqual(new Point(15, 15), _shape.GetSecond());
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Scale_ChangesShapeSize()
        {
            // Arrange
            var scalePoint = new Point(0, 0);
            var delta = new Point(5, 5);

            // Act
            _shape.Scale(scalePoint, delta);

            // Assert
            Assert.AreEqual(new Point(5, 5), _shape.GetFirst());
            Assert.AreEqual(new Point(10, 10), _shape.GetSecond());

            scalePoint = new Point(10, 10);
            _shape.Scale(scalePoint, delta);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void IsPointIn_ReturnsTrueWhenPointIsInShape()
        {
            // Arrange
            var point = new Point(5, 5);

            // Act
            var result = _shape.IsPointIn(point);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void GetFixedInfo_ReturnsCorrectInfo()
        {
            // Act
            var result = _shape.GetFixedInfo();

            // Assert
            Assert.AreEqual(new Point(0, 0), result[0]);
            Assert.AreEqual(new Point(10, 10), result[1]);
        }
    }

    public class MockShape : Shape
    {
        public MockShape(Point start, Point end, Point canvas) : base(start, end, canvas)
        {
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            // Mock implementation
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public override string GetShapeName()
        {
            return "MockShape";
        }
    }
}