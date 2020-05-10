using System;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Soft {

    public class NavButtonsAcceptanceTests {

        private IHtmlAnchorElement firstBtn;
        private IHtmlAnchorElement prevBtn;
        private IHtmlAnchorElement nextBtn;
        private IHtmlAnchorElement lastBtn;
        private IHtmlAnchorElement pagesInfo;

        private readonly Func<Task> addToDatabase;
        private readonly Func<string> pageUrl;
        private readonly Func<int> getNumberOfPages;
        private readonly Func<string> baseUrl;
        private readonly Func<string, IHtmlDocument> sendRequest;
        private IHtmlDocument htmlDocument;
        private int numberOfPages => getNumberOfPages();

        public NavButtonsAcceptanceTests(Func<Task> db,
            Func<string> getPageUrl,
            Func<string> getBaseUrl,
            Func<int> getNoOfPages,
            Func<string, IHtmlDocument> sendUrl) {
            addToDatabase = db;
            pageUrl = getPageUrl;
            baseUrl = getBaseUrl;
            getNumberOfPages = getNoOfPages;
            sendRequest = sendUrl;
        }

        public async Task DoTest() {

            await addToDatabase();
            testNavButtons(pageUrl(), 1, 0, 2, numberOfPages);
            testNextButton();
            testPreviousButton();
            testFirstButton();
            testLastButton();
        }

        private void testLastButton() {
            testNavButtons(firstBtn.Href, 1, 0, 2, numberOfPages);

            for (var i = 2; i <= numberOfPages; i++) {
                Assert.IsNotNull(nextBtn);
                testNavButtons(nextBtn.Href, 1, i - 1, i + 1, numberOfPages);
                var nextNext = nextBtn;
                testNavButtons(lastBtn.Href, 1, numberOfPages - 1, numberOfPages + 1, numberOfPages);
                nextBtn = nextNext;
            }
        }

        private void testPreviousButton() {
            testNavButtons(lastBtn.Href, 1, numberOfPages - 1, numberOfPages + 1, numberOfPages);

            for (var i = numberOfPages - 1; i > 0; i--) {
                Assert.IsNotNull(prevBtn);
                testNavButtons(prevBtn.Href, 1, i - 1, i + 1, numberOfPages);
            }
        }

        private void testNextButton() {

            for (var i = 2; i <= numberOfPages; i++) {
                Assert.IsNotNull(nextBtn);
                testNavButtons(nextBtn.Href, 1, i - 1, i + 1, numberOfPages);
            }
        }

        private void testFirstButton() {
            for (var i = 2; i <= numberOfPages; i++) {
                Assert.IsNotNull(nextBtn);
                testNavButtons(nextBtn.Href, 1, i - 1, i + 1, numberOfPages);
                var nextNext = nextBtn;
                testNavButtons(firstBtn.Href, 1, 0, 2, numberOfPages);
                nextBtn = nextNext;
            }
        }

        protected void testNavButtons(string url, int firstIdx, int prevIdx, int nextIdx, int lastIdx) {
            htmlDocument = sendRequest(url);
            findNavLinks();
            testNavLinks(firstIdx, prevIdx, nextIdx, lastIdx);
        }


        private void testNavLinks(in int firstIdx, in int prevIdx, in int nextIdx, in int lastIdx) {
            var id = nextIdx - 1;
            var firstLink = navLink("Esimene", firstIdx, id < 2);
            var prevLink = navLink("Eelmine", prevIdx, id < 2);
            var nextLink = navLink("Järgmine", nextIdx, id > lastIdx - 1);
            var lastLink = navLink("Viimane", lastIdx, id > lastIdx - 1);
            Assert.AreEqual(firstLink, firstBtn.OuterHtml);
            Assert.AreEqual(prevLink, prevBtn.OuterHtml);
            Assert.AreEqual(nextLink, nextBtn.OuterHtml);
            Assert.AreEqual(lastLink, lastBtn.OuterHtml);
        }

        private void findNavLinks() {
            firstBtn = htmlDocument.FindAnchorElement("a[id='firstButton']");
            prevBtn = htmlDocument.FindAnchorElement("a[id='previousButton']");
            nextBtn = htmlDocument.FindAnchorElement("a[id='nextButton']");
            lastBtn = htmlDocument.FindAnchorElement("a[id='lastButton']");
            pagesInfo = htmlDocument.FindAnchorElement("a[id='pagesInfo']");
        }

        protected string navLink(string displayName, int? pageIndex = null, bool isDisabled = false) {
            var disabled = isDisabled ? "disabled" : string.Empty;
            var id = displayName.ToLower() + "Button";

            return
                $"<a id=\"{id}\" href=\"{baseUrl()}/Index?handler=Index&amp;pageIndex={pageIndex}\" class=\"btn btn-link {disabled}\">{displayName}</a>";
        }

    }

}