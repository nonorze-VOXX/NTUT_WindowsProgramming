using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;
using Unity.ShapeModelState;

namespace Unity.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        private DrawingState _drawingState;
        private Mock<IGraphics> _mockGraphics;
        private Mock<CommandManager> _mockCommandManager;
        private BindingList<Shape> _shapeList;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _drawingState = new DrawingState();
            _mockGraphics = new Mock<IGraphics>();
            _mockCommandManager = new Mock<CommandManager>();
            _shapeList = new BindingList<Shape>();
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void DeletePress_DoesNothing()
        {
            _drawingState.DeletePress(_shapeList, _mockCommandManager.Object);
            // Add assertions here
        }


        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Draw_DrawsHintShape()
        {
            _drawingState.Draw(_mockGraphics.Object, _shapeList);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseDown_CreatesNewShapeAndAddCommand()
        {
            var point = new Point(5, 5);
            _drawingState.MouseDown(ShapeType.Line, point, _shapeList, point);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void IsScale_ReturnsFalse()
        {
            var result = _drawingState.IsScale(_shapeList);
            Assert.IsFalse(result);
        }


        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseMove_SetsSecondPointOfHintShape()
        {
            var point = new Point(5, 5);
            _drawingState.MouseMove(point, true, _shapeList);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseUp_SetsSecondPointOfHintShapeAndAddsShapeToList()
        {
            var point = new Point(5, 5);
            _drawingState.MouseDown(ShapeType.Line, point, _shapeList, point);
            _drawingState.MouseUp(point, _shapeList, _mockCommandManager.Object);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Reset_DoesNothing()
        {
            _drawingState.Reset();
            // Add assertions here
        }
    }
}