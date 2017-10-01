using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace AutoTests
{
    [TestClass]
    public class UITests
    {
        public static Application application;

        [TestCleanup]
        public void TestTearDown()
        {
            application.Close();
        }

        [TestInitialize]
        public void SetUp()
        {
            application = Application.Launch(@"E:\CSharpDev\MyPreviousVersions\2017.09.22\Painter\...");
            Assert.IsNotNull(application);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
