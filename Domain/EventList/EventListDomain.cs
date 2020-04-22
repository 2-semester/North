using North.Data.EventList;
using North.Domain.Common;

namespace North.Domain.EventList
{
    public sealed class EventListDomain : Entity<EventListData>
    {
        public EventListDomain() : this(null) { }
        public EventListDomain(EventListData data) : base(data) { }
    }
}
