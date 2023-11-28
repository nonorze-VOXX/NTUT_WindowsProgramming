﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            var shapeModel = new Mock<ShapeModel>();
            var presentationModel = new Mock<PresentationModel>(shapeModel.Object);
            var form = new Form1(presentationModel.Object);
            var formPrivate = new PrivateObject(form);
            Assert.IsNotNull(formPrivate.GetField("_presentationModel"));

        }
    }
}