using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Facade.Event;
using North.Pages.Extensions;
using North.Tests.Aids;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class TableHeaderForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TableHeaderForHtmlExtension);
        }

        [TestMethod]
        public void TableHeaderForTest()
        {
            var obj = new htmlHelperMock<EventView>().TableHeaderFor(
                GetRandomTests.Object<Link>(),
                GetRandomTests.Object<Link>(),
                GetRandomTests.Object<Link>(),
                GetRandomTests.Object<Link>()
            );
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
    }
}