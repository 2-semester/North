using North.Data.Event;
using North.Domain.Event;

namespace North.Infra.Event
{
    public sealed class EventsRepository : UniqueEntityRepository<EventDomain, EventData>, IEventsRepository
    {
        public EventsRepository(NorthDbContext c) : base(c, c.Events) { }

        protected internal override EventDomain toDomainObject(EventData d) => new EventDomain(d);
    }
}
