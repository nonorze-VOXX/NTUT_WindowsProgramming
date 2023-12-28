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
            Page page = new Page();
            PresentationModel presentationModel = new PresentationModel(page);
            var form = new Form1(presentationModel);
            page.Attach(form);
            Application.Run(form);
        }
    }
}