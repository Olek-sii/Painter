using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace AutoTests
{
	[TestClass]
    public class UITests
    {
        private Application _application;
		private Window _mainWindow;

		[TestCleanup]
        public void TestTearDown()
        {
			_mainWindow.Close();
            _application.Close();
        }

        [TestInitialize]
        public void SetUp()
        {
			_application = Application.Launch(@"E:\projects\c#\Painter\plugins\Painter.exe");
			_mainWindow = _application.GetWindows()[0];
		}

        [TestMethod]
        public void TestMenu()
        {
			_mainWindow.Get(SearchCriteria.ByText("File")).Click();
			_mainWindow.Get(SearchCriteria.ByText("Open")).Click();
			var a = _mainWindow.ModalWindows()[0].Get(SearchCriteria.ByText("File open"));
			Assert.IsNotNull(a);
			_mainWindow.ModalWindows()[0].Close();
		}
    }
}
