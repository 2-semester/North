using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Event;
using North.Facade.EventList;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class DisabledControlsForHtmlExtensionTests :BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(DisabledControlsForHtmlExtension);

        [TestMethod]
        public void DisabledControlsForTest()
        {
            var obj = new htmlHelperMock<EventListView>().DisabledControlsFor(x => x.EventId);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<div","<fieldset disabled>","LabelFor", "EditorFor", "ValidationMessageFor","</fieldset>","</div>" };
            var actual =DisabledControlsForHtmlExtension.htmlString(new htmlHelperMock<EventView>(), x => x.Name);
            TestHtml.Strings(actual, expected);
        }
    }
}
