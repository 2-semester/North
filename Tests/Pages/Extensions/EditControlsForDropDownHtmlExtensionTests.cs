using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.EventList;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForDropDownHtmlExtensionTests : BaseTests
    {

        private readonly List<SelectListItem> items = new List<SelectListItem> {new SelectListItem("text", "value")};

        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(EditControlsForDropDownHtmlExtension);

        [TestMethod]
        public void EditControlsForDropDownTest()
        {
            var obj = new htmlHelperMock<EventListView>().EditControlsForDropDown(x => x.EventId, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> {"<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>"};
            var actual = EditControlsForDropDownHtmlExtension.htmlStrings(new htmlHelperMock<EventListView>(),
                x => x.EventId, items);
            TestHtml.Strings(actual, expected);
        }
    }
}