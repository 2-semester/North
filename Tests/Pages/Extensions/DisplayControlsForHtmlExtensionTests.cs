using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Event;
using North.Facade.EventList;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class DisplayControlsForHtmlExtensionTests: BaseTests 
    {
        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(DisplayControlsForHtmlExtension ); 

        [TestMethod]
        public void DisplayControlsForTest()
        {
            var obj = new htmlHelperMock<EventListView>().DisplayControlsFor(x => x.EventId);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<dt", "DisplayNameFor", "</dt>", "<dd", "DisplayFor", "</dd>" };
            var actual =
                DisplayControlsForHtmlExtension.htmlStrings(new htmlHelperMock<EventView>(), x => x.Id);
            TestHtml.Strings(actual, expected);
        }
    }
}
