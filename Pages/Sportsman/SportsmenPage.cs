using North.Data.Sportsman;
using North.Domain.Sportsman;
using North.Facade.Sportsman;

namespace North.Pages.Sportsman
{
    public abstract class SportsmenPage : CommonPage<ISportsmenRepository, SportsmanDomain,
        SportsmanView, SportsmanData>
    {
        protected internal SportsmenPage(ISportsmenRepository r): base(r)
        {
            PageTitle = "Sportlane";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Sportsman/Sportsmen";

        protected internal override SportsmanDomain toObject(SportsmanView view)
        {
            return SportsmanViewFactory.Create(view);
        }

        protected internal override SportsmanView toView(SportsmanDomain obj)
        {
            return SportsmanViewFactory.Create(obj);
        }
    }
}
