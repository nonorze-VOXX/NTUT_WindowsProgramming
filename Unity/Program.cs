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
            PageModel pageModel = new PageModel();
            PresentationModel presentationModel = new PresentationModel(pageModel);
            var form = new Form1(presentationModel);
            pageModel.Attach(form);
            Application.Run(form);
        }
    }
}