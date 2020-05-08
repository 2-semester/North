using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;
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
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>()
            );
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
    }
}