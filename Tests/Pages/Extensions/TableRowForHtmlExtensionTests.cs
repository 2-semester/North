using System;
using System.Collections.Generic;
using Abc.Aids.Random;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Facade.Event;
using North.Pages.Extensions;
using North.Tests.Aids;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class TableRowForHtmlExtensionTests : BaseTests
    {
        private string s;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TableRowForHtmlExtension);
            s = GetRandom.String();
        }

        [TestMethod]
        public void TableRowForTest()
        {
            var obj = new htmlHelperMock<EventView>().TableRowFor(

                GetRandom.String(),
                new htmlContentMock(GetRandom.String()),
                new htmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void TableRowWithoutEditForTest()
        {
            var obj = new htmlHelperMock<EventView>().TableRowFor(

                GetRandom.String(),
                new htmlContentMock(GetRandom.String()),
                new htmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
        [TestMethod]
        public void addValueTest()
        {
            var value = new htmlContentMock(s);
            var l = new List<object>();
            TableRowForHtmlExtension.addValue(l, value);
            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("<td>", l[0].ToString());
            Assert.AreEqual(s, l[1].ToString());
            Assert.AreEqual("</td>", l[2].ToString());
        }
    }
}