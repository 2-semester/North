using North.Data.EventList;
using North.Domain.EventList;

namespace North.Infra.EventList
{
    public sealed class EventListsRepository : UniqueEntityRepository<EventListDomain, EventListData>, IEventListsRepository
    {
        public EventListsRepository(EventListDbContext c) : base(c, c.EventLists) { }

        protected internal override EventListDomain toDomainObject(EventListData d) => new EventListDomain(d);
    }
}
