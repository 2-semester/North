using North.Data.EventList;
using North.Domain.Common;

namespace North.Domain.EventList
{
    public sealed class EventList : Entity<EventListData>
    {
        public EventList() : this(null) { }
        public EventList(EventListData data) : base(data) { }
    }
}
