using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{

    [TestClass]
    public class EditControlsForEnumHtmlExtensionTests : BaseTests
    {
        //private class testClass : NamedView
        //{
        //    public IsoGender Gender { get; set; }
        //}

        //[TestInitialize] public virtual void TestInitialize() => type = typeof(EditControlsForEnumHtmlExtension);

        //[TestMethod]
        //public void EditControlsForEnumTest()
        //{
        //    var obj = new htmlHelperMock<testClass>().EditControlsForEnum(x => x.Gender);
        //    Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        //}

        //[TestMethod]
        //public void HtmlStringsTest()
        //{
        //    var selectList = new SelectList(Enum.GetNames(typeof(IsoGender)));
        //    var expected = new List<string> { "<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>" };
        //    var actual = EditControlsForEnumHtmlExtension.htmlStrings(new htmlHelperMock<testClass>(),
        //        x => x.Gender, selectList);
        //    TestHtml.Strings(actual, expected);
        //}


    }

}