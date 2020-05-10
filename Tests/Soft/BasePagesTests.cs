using North.Aids.Extensions;

namespace North.Tests.Soft {

    public abstract class BasePagesTests<TData> : BasePageTests {

        protected TData item;
        protected bool isCreatePage => pageName == "Loo uus";
        protected bool isEditPage => pageName == "Muuda";
        protected bool isDeletePage => pageName == "Kustuta";
        protected bool isDetailsPage => pageName == "Lisainfo";
        protected bool isIndexPage => pageName == "Index";

        protected string pageName => GetType().Name.SubstringBefore("PageTests");

        protected abstract string baseUrl();

        protected override string pageUrl() => baseUrl() + pageHandlerUrl(pageName);

        protected string indexPageUrl() => baseUrl() + pageHandlerUrl("Index");

        private string pageHandlerUrl(string s) {

            var h = s == "Select" ? "Index" : s;

            var u = $"/{h}?handler={h}";

            if (s == "Index" || s == "Create") return u;

            return $"{u}&id={itemId(item)}";
        }

        protected abstract string itemId(TData d);
        protected abstract void setId(TData d, string id);

    }

}
