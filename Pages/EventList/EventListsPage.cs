using North.Data.EventList;
using North.Domain.EventList;
using North.Facade.EventList;

namespace North.Pages.EventList
{
    public class EventListsPage : CommonPage<IEventListsRepository, EventListDomain,
        EventListView, EventListData>
    {
        protected internal EventListsPage(IEventListsRepository r) : base(r)
        {
            PageTitle = "Ürituste sarjad";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/EventList/EventLists";

        protected internal override EventListDomain toObject(EventListView view)
        {
            return EventListViewFactory.Create(view);
        }

        protected internal override EventListView toView(EventListDomain obj)
        {
            return EventListViewFactory.Create(obj);
        }
    }
}
