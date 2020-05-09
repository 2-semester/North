using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Event;
using North.Facade.EventList;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class DropDownNavigationMenuForHtmlExtensionTests : BaseTests
    {
        private string name;
        private Link[] items;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DropDownNavigationMenuForHtmlExtension);
        }

        [TestMethod]
        public void DropDownNavigationMenuForTest()
        {
            Assert.Inconclusive();
            //var obj = new htmlHelperMock<EventView>().DropDownNavigationMenuFor(name, items);
            //Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
    }
}