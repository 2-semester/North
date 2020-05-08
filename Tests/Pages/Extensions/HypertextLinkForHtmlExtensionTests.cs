using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Facade.EventList;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class HypertextLinkForHtmlExtensionTests : BaseTests
    {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(HypertextLinkForHtmlExtension);

        [TestMethod]
        public void HypertextLinkForTest()
        {
            var s = GetRandom.String();
            var items = new[] { new Link("AA", "AAA"), new Link("BB", "BBB") };
            var obj = new htmlHelperMock<EventListView>().HypertextLinkFor(s, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var s = GetRandom.String();
            var items = new[] { new Link("AA", "AAA"), new Link("BB", "BBB") };
            var expected = new List<string> {
                "<p>", $"<a>{s}</a>", $"<a> </a><a href=\"AAA\">AA</a>",
                $"<a> </a><a href=\"BBB\">BB</a>", "</p>"
            };
            var actual = HypertextLinkForHtmlExtension.htmlStrings(s, items);
            TestHtml.Strings(actual, expected);
        }

    }
}