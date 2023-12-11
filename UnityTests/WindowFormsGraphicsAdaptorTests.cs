using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass()]
    public class WindowFormsGraphicsAdaptorTests
    {
        private Graphics _graphics;
        private WindowFormsGraphicsAdaptor windowFormsGraphicsAdaptor;


        /// <summary>
        /// set
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            _graphics = Graphics.FromImage(new Bitmap(1, 1));
            windowFormsGraphicsAdaptor = new WindowFormsGraphicsAdaptor(_graphics);
        }

        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void DrawEllipseTest()
        {
            windowFormsGraphicsAdaptor.DrawEllipse(new Point(0, 0), new Point(0, 0));
        }

        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void DrawEllipseByCenterAndSizeTest()
        {
            windowFormsGraphicsAdaptor.DrawEllipseByCenterAndSize(new Point(1, 1), new Point(1, 1));
        }

        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void DrawLineTest()
        {
            windowFormsGraphicsAdaptor.DrawLine(new Point(0, 0), new Point(0, 0));
        }

        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void DrawRectangleTest()
        {
            windowFormsGraphicsAdaptor.DrawRectangle(new Point(0, 0), new Point(0, 0));
            windowFormsGraphicsAdaptor.DrawRectangle(new Point(0, 0), new Point(0, 0), Pens.Red);
        }
    }
}