using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Extensions;

namespace North.Tests.Soft
{
    public class TableHeadersAcceptanceTests<TView>
    {

        private readonly Func<Task> addToDatabase;
        private readonly Func<string> pageUrl;
        private readonly Func<string> baseUrl;
        private readonly Func<string, IHtmlDocument> sendRequest;
        private IHtmlDocument htmlDocument;
        private readonly IEnumerable<Expression<Func<TView, object>>> indexPageColumns;
        public TableHeadersAcceptanceTests(Func<Task> db,
            Func<string> getPageUrl,
            Func<string> getBaseUrl,
            Func<string, IHtmlDocument> sendUrl,
            IEnumerable<Expression<Func<TView, object>>> columns
            )
        {
            addToDatabase = db;
            pageUrl = getPageUrl;
            baseUrl = getBaseUrl;
            sendRequest = sendUrl;
            indexPageColumns = columns;
        }

        public async Task DoTest()
        {

            await addToDatabase();

            foreach (var e in indexPageColumns) { testClickHeader(e); }
        }

        private void testClickHeader(Expression<Func<TView, object>> e)
        {
            var isDesc = false;
            var name = GetMember.Name(e);
            var displayName = GetMember.DisplayName(e);
            var id = displayName.ToLowerCase().RemoveSpaces() + "Column";
            htmlDocument = sendRequest(pageUrl());

            for (var i = 0; i < 3; i++)
            {
                var link = htmlDocument.FindAnchorElement($"a[id='{id}']");
                Assert.IsNotNull(link);
                var sortOrder = name;
                sortOrder = isDesc ? sortOrder + "_desc" : sortOrder;
                var expected = $"<a id=\"{id}\" href=\"{baseUrl()}?handler=Index" +
                               $"&amp;sortOrder={sortOrder}&amp;" +
                               "currentFilter=&amp;" +
                               "searchString=&amp;" +
                               "fixedFilter=&amp;" +
                               "fixedValue=\">" +
                               $"<span style=\"font-weight:normal\">{displayName}</span></a>";
                Assert.AreEqual(expected, link.OuterHtml);
                isDesc = !isDesc;
                htmlDocument = sendRequest(link.Href);
            }
        }

    }
}
