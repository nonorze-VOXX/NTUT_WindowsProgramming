using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Command.CommandManagerManager.Tests
{
    [TestClass()]
    public class CommandManagerManagerTests
    {
        [TestMethod()]
        public void AddRemovePagecommandTest()
        {
            var cmm = new CommandManagerManager();
            cmm.Clear();

            /*
            var model = new PageModel();
            var _presentationModel = new PresentationModel(model);
            var form = new Form1(_presentationModel);
            _presentationModel.AddFirstPage(0, form);
            var page = new Page();
            cmm.AddRemovePagecommand(form, 1, page);
            var pages = new List<Page>();
            pages.Add(new Page());
            pages.Add(new Page());
            pages.Add(new Page());
            cmm.Undo(pages);
            cmm.Redo(pages);
            */
        }

    }
}