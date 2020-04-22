using North.Aids;
using North.Data.EventList;
using North.Domain.EventList;

namespace North.Facade.EventList
{
    public static class EventListViewFactory
    {
        public static EventListDomain Create(EventListView view)
        {
            var d = new EventListData();
            Copy.Members(view, d);
            return new EventListDomain(d);
        }

        public static EventListView Create(EventListDomain obj)
        {
            var v = new EventListView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
