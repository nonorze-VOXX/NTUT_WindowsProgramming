using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Unity.Tests
{
    [TestClass()]
    public class WindowFormsGraphicsAdaptorTests
    {
        private Graphics _graphics;
        private WindowFormsGraphicsAdaptor windowFormsGraphicsAdaptor;


        [TestInitialize()]
        public void SetUp()
        {
            _graphics = Graphics.FromImage(new Bitmap(1, 1));
            windowFormsGraphicsAdaptor = new WindowFormsGraphicsAdaptor(_graphics);
        }

        [TestMethod()]
        public void DrawEllipseTest()
        {
            windowFormsGraphicsAdaptor.DrawEllipse(new Point2(0, 0), new Point2(0, 0));
        }

        [TestMethod()]
        public void DrawEllipseByCenterAndSizeTest()
        {
            windowFormsGraphicsAdaptor.DrawEllipseByCenterAndSize(new Point2(1, 1), new Point2(1, 1));
        }

        [TestMethod()]
        public void DrawLineTest()
        {
            windowFormsGraphicsAdaptor.DrawLine(new Point2(0, 0), new Point2(0, 0));
        }

        [TestMethod()]
        public void DrawRectangleTest()
        {
            windowFormsGraphicsAdaptor.DrawRectangle(new Point2(0, 0), new Point2(0, 0));
            windowFormsGraphicsAdaptor.DrawRectangle(new Point2(0, 0), new Point2(0, 0), Pens.Red);
        }
    }
}