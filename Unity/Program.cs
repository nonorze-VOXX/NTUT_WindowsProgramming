using System;
using System.Windows.Forms;

namespace Unity
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShapeModel shapeModel = new ShapeModel();
            PresentationModel presentationModel = new PresentationModel(shapeModel);
            shapeModel.Attach(presentationModel);
            Form1 form = new Form1(shapeModel, presentationModel);
            shapeModel.Attach(form);
            Application.Run(form);
        }
    }
}