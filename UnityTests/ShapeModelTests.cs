using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass]
    public class ShapeModelTests
    {
        private ShapeModel _shapeModel;
        private Mock<IGraphics> _mockGraphics;
        private Mock<IShapeObserver> _mockShapeObserver;
        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _shapeModel = new ShapeModel();
            _mockGraphics = new Mock<IGraphics>();
            _mockShapeObserver = new Mock<IShapeObserver>();
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void utils()
        {
            _shapeModel.Add(ShapeType.Line);
            _shapeModel.Resize(new Point(1, 1));
            _shapeModel.Draw(_mockGraphics.Object);
            _shapeModel.Attach(_mockShapeObserver.Object);
            _shapeModel.MouseDown(ShapeType.Line, new Point(1, 1));
            _shapeModel.MouseUp(new Point(1, 1));
            _shapeModel.RemoveIndex(0);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void SwitchStateDrawing_SetsStateToDrawingState()
        {
            _shapeModel.SwitchStateDrawing();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void SwitchStatePoint_SetsStateToPointState()
        {
            _shapeModel.SwitchStatePoint();
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void IsScale_ReturnsCorrectValue()
        {
            var result = _shapeModel.IsScale();
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Resize_ResizesShapes()
        {
            var point = new Point(5, 5);
            _shapeModel.Resize(point);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Draw_DrawsShapes()
        {
            _shapeModel.Draw(_mockGraphics.Object);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Attach_AttachesObserver()
        {
            _shapeModel.Attach(_mockShapeObserver.Object);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Detach_DetachesObserver()
        {
            _shapeModel.Detach(_mockShapeObserver.Object);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseDown_UpdatesState()
        {
            var point = new Point(5, 5);
            _shapeModel.MouseDown(ShapeType.Line, point);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseUp_UpdatesState()
        {
            var point = new Point(5, 5);
            _shapeModel.MouseUp(point);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseMove_UpdatesState()
        {
            var point = new Point(5, 5);
            _shapeModel.MouseMove(point);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Add_AddsShape()
        {
            _shapeModel.Add(ShapeType.Line);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void RemoveIndex_RemovesShape()
        {
            var index = 0;
            _shapeModel.RemoveIndex(index);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void DeletePress_DeletesShape()
        {
            _shapeModel.DeletePress();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Undo_UndoesLastAction()
        {
            _shapeModel.Undo();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Redo_RedoLastAction()
        {
            _shapeModel.Redo();
            // Add assertions here
        }
    }
}