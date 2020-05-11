using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Tests.Soft;
using AngleSharp.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Extensions;
using North.Data.Common;

namespace North.Tests.Soft
{

    public abstract class BaseAcceptanceTests<TView, TData, TContext> : BaseControlsTests<TView, TData, TContext>
        where TContext : DbContext where TData : PeriodData
    {

        [TestMethod]
        public void CanClickBackToListLinkTest()
        {
            Assert.Inconclusive();
            //htmlDocument = sendRequest(pageUrl());
            //var e = htmlDocument.FindAnchorElement("a[id='backToList']");

            //sendRequest(e.Href);
            //var expected = HtmlTag.IndexForm(baseUrl());

            //if (pageHtml.Contains(expected)) return;

            //Assert.AreEqual(pageHtml, expected);
        }

        [TestMethod]
        public void HasLinkInIndexPageTest()
        {

            Assert.Inconclusive();
            //sendRequest(indexPageUrl());

            //if (pageHtml.Contains(pageUrl())) return;

            //Assert.AreEqual(pageHtml, pageUrl());
        }

        [TestMethod]
        public async Task CanClickNavButtonsTest()
        {
            Assert.Inconclusive();
            //if (!isIndexPage) return;
            //var tests = new NavButtonsAcceptanceTests(addToDatabase,
            //    pageUrl, baseUrl, () => numberOfPages, sendRequest);
            //await tests.DoTest();
        }

        protected abstract IEnumerable<Expression<Func<TView, object>>> indexPageColumns { get; }

        [TestMethod]
        public async Task CanClickTableHeadersTest()
        {
            Assert.Inconclusive();
            //if (!isIndexPage) return;
            //var tests = new TableHeadersAcceptanceTests<TView>(addToDatabase,
            //    pageUrl, baseUrl, sendRequest, indexPageColumns);
            //await tests.DoTest();
        }

        [TestMethod]
        public async Task CanClickDeleteButtonTest()
        {
            if (!isDeletePage) return;
            var db = getContext<TContext>();
            await addToDatabase();
            var id = itemId(item);
            var x = await db.FindAsync<TData>(toComposedId(id));
            Assert.AreEqual(id, itemId(x));

            htmlDocument = sendRequest(pageUrl());
            var form = htmlDocument.FindFormElement("form[id='deleteForm']");
            var button = htmlDocument.FindInputElement("input[id='deleteButton']");
            var m = HtmlDoc.ComposeRequestMessage(form, button);

            htmlDocument = sendRequest(m);

            var expected = HtmlTag.IndexForm(baseUrl());

            db = getContext<TContext>();
            x = await db.FindAsync<TData>(toComposedId(id));
            Assert.IsNull(x);

            if (pageHtml.Contains(expected)) return;

            Assert.AreEqual(pageHtml, expected);

        }

        [TestMethod]
        public async Task CanClickCreateButtonTest()
        {
            if (!isCreatePage) return;
            var db = getContext<TContext>();
            await addToDatabase();
            item = randomItem();
            await addRelatedItems(item);
            var id = itemId(item);
            var x = await db.FindAsync<TData>(toComposedId(id));
            Assert.IsNull(x);

            htmlDocument = sendRequest(pageUrl());
            var form = htmlDocument.FindFormElement("form[id='createForm']");
            var button = htmlDocument.FindInputElement("input[id='createButton']");
            var m = HtmlDoc.ComposeRequestMessage(form, button, item);

            htmlDocument = sendRequest(m);

            var expected = HtmlTag.IndexForm(baseUrl());

            db = getContext<TContext>();
            x = await db.FindAsync<TData>(toComposedId(id));
            Assert.IsNotNull(x);
            Assert.AreEqual(id, itemId(x));
            testArePropertyValuesEqual(item, x);

            if (pageHtml.Contains(expected)) return;

            Assert.AreEqual(pageHtml, expected);

        }

        [TestMethod]
        public async Task CanClickEditButtonTest()
        {
            if (!isEditPage) return;
            var db = getContext<TContext>();
            await addToDatabase();
            var id = itemId(item);
            await addRelatedItems(item);
            var x = await db.FindAsync<TData>(toComposedId(id));
            Assert.AreEqual(id, itemId(x));

            item = randomItem();
            await addRelatedItems(item);
            setId(item, id);

            htmlDocument = sendRequest(pageUrl());
            var form = htmlDocument.FindFormElement("form[id='editForm']");
            var button = htmlDocument.FindInputElement("input[id='saveButton']");
            var m = HtmlDoc.ComposeRequestMessage(form, button, item);

            htmlDocument = sendRequest(m);

            var expected = HtmlTag.IndexForm(baseUrl());

            db = getContext<TContext>();
            x = await db.FindAsync<TData>(toComposedId(id));
            Assert.IsNotNull(x);
            Assert.AreEqual(id, itemId(x));
            testArePropertyValuesEqual(item, x);

            if (pageHtml.Contains(expected)) return;

            Assert.AreEqual(pageHtml, expected);

        }

        protected abstract Task addRelatedItems(TData d);

        [TestMethod]
        public override void IsTested()
        {
            isCorrectPageName();
        }

        [TestMethod]
        public override void IsSpecifiedClassTested()
        {
            isCorrectItem();
            isCorrectContext();
        }

        private void isCorrectPageName()
        {
            var n = baseClassName();
            var title = baseClassName();
            Assert.AreEqual(title, n);
        }

        private string pageTitle()
        {
            htmlDocument = sendRequest(pageUrl());
            var header = htmlDocument.FindElement("h1");
            var title = header.TextContent.RemoveSpaces();
            title = toSingular(title);

            return title;
        }

        protected virtual string toSingular(string title)
        {
            return title.Substring(0, title.Length - 1);
        }

        private void isCorrectItem()
        {
            var n = baseClassName();
            var itemName = item.GetType().Name;
            Assert.IsTrue(itemName.StartsWith(n), $"Not testing {n}");
        }

        protected string baseClassName()
        {
            var n = GetType().BaseType?.Name;
            n = n.ReplaceFirst("Base", string.Empty);
            n = n.ReplaceFirst("sTests", string.Empty);

            return n;
        }

        private void isCorrectContext()
        {
            var n = baseBaseClassName();
            var db = getContext<TContext>();
            var contextName = db.GetType().Name;
            Assert.IsTrue(contextName.StartsWith(n), $"Not testing {n}");
        }

        private string baseBaseClassName()
        {
            var s = GetType().BaseType?.BaseType?.Name;
            s = s.ReplaceFirst("Base", string.Empty);
            s = s.Substring(0, s.IndexOf("Tests", StringComparison.Ordinal));

            return s;
        }

    }

}
