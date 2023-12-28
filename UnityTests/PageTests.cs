using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass]
    public class PageTests
    {
        private Page _page;
        private Mock<IGraphics> _mockGraphics;
        private Mock<IShapeObserver> _mockShapeObserver;
        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _page = new Page();
            _mockGraphics = new Mock<IGraphics>();
            _mockShapeObserver = new Mock<IShapeObserver>();
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void utils()
        {
            _page.Add(ShapeType.Line);
            _page.Resize(new Point(1, 1));
            _page.Draw(_mockGraphics.Object);
            _page.Attach(_mockShapeObserver.Object);
            _page.MouseDown(ShapeType.Line, new Point(1, 1));
            _page.MouseUp(new Point(1, 1));
            _page.RemoveIndex(0);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void SwitchStateDrawing_SetsStateToDrawingState()
        {
            _page.SwitchStateDrawing();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void SwitchStatePoint_SetsStateToPointState()
        {
            _page.SwitchStatePoint();
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void IsScale_ReturnsCorrectValue()
        {
            var result = _page.IsScale();
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Resize_ResizesShapes()
        {
            var point = new Point(5, 5);
            _page.Resize(point);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Draw_DrawsShapes()
        {
            _page.Draw(_mockGraphics.Object);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Attach_AttachesObserver()
        {
            _page.Attach(_mockShapeObserver.Object);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Detach_DetachesObserver()
        {
            _page.Detach(_mockShapeObserver.Object);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseDown_UpdatesState()
        {
            var point = new Point(5, 5);
            _page.MouseDown(ShapeType.Line, point);
            // Add assertions here
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseUp_UpdatesState()
        {
            var point = new Point(5, 5);
            _page.MouseUp(point);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseMove_UpdatesState()
        {
            var point = new Point(5, 5);
            _page.MouseMove(point);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Add_AddsShape()
        {
            _page.Add(ShapeType.Line);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void RemoveIndex_RemovesShape()
        {
            var index = 0;
            _page.RemoveIndex(index);
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void DeletePress_DeletesShape()
        {
            _page.DeletePress();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Undo_UndoesLastAction()
        {
            _page.Undo();
            // Add assertions here
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Redo_RedoLastAction()
        {
            _page.Redo();
            // Add assertions here
        }
    }
}