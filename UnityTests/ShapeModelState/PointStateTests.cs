using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel;
using System.Drawing;
using Unity.ShapeModelState;

namespace Unity.Tests
{
    [TestClass]
    public class PointStateTests
    {
        private PointState _pointState;
        private BindingList<Shape> _shapes;
        private Mock<IGraphics> _mockGraphics;
        private Shape _shape;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _pointState = new PointState();
            _shape = new Line(new Point(1, 1), new Point(1, 1), new Point(1, 1)); // Replace with your actual Shape object
            _mockGraphics = new Mock<IGraphics>();
            _shapes = new BindingList<Shape> { _shape };
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void AllTest()
        {
            _pointState.SetChoosingIndex(0);
            _pointState.Draw(_mockGraphics.Object, _shapes);
            _pointState.DeletePress(_shapes, new Command.CommandManager());
            _pointState.MouseDown(ShapeType.Line, new Point(1, 1), _shapes, new Point(1, 1));
            _pointState.SetChoosingIndex(0);
            _shapes.Add(_shape);
            _pointState.MouseDown(ShapeType.Line, new Point(1, 1), _shapes, new Point(1, 1));
            _pointState.SetChoosingIndex(-1);
            _pointState.IsWhichCircle(_shapes);
            _pointState.SetChoosingIndex(0);
            _pointState.SetPastPoint(new Point(-20, -20));
            _pointState.IsWhichCircle(_shapes);
            _pointState.IsScale(_shapes);
            _pointState.SetScalePoint(new Point(-1, -1));
            _pointState.IsScale(_shapes);
            _pointState.MoveLogic(new Point(1, 1), _shapes);
            _pointState.MoveLogic(new Point(-1, -1), _shapes);
            _pointState.SetScalePoint(new Point(1, 1));
            _pointState.SetChoosingIndex(0);
            _pointState.MouseMove(new Point(1, 1), true, _shapes);
            _pointState.MouseUp(new Point(1, 1), _shapes, new Command.CommandManager());
            _pointState.Reset();

        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseMove_WhenPressedAndChoosingIndexNotNegative_MovesShape()
        {
            _pointState.MouseMove(new Point(5, 5), true, _shapes);
            // Add assertions here to verify that the shape was moved
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void MouseMove_WhenScalePointNotNegative_ScalesShape()
        {
            // Set _scalePoint to a value other than (-1, -1) before calling MouseMove
            _pointState.SetChoosingIndex(0);
            _pointState.MouseMove(new Point(5, 5), true, _shapes);
            // Add assertions here to verify that the shape was scaled
        }
    }
}