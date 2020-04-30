using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Aids;
using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;

namespace North.Infra.SportsmanEvent
{
    public sealed class SportsmanEventsRepository : PaginatedRepository<SportsmanEventDomain, SportsmanEventData>, ISportsmanEventsRepository
    {
        public SportsmanEventsRepository(NorthDbContext c) : base(c, c.SportsmanEvents) { }

        protected internal override SportsmanEventDomain toDomainObject(SportsmanEventData d) => new SportsmanEventDomain(d);
        protected override async Task<SportsmanEventData> getData(string id)
        {
            var sportsManId = GetString.Head(id);
            var eventId = GetString.Tail(id);

            return await dbSet.SingleOrDefaultAsync(x => x.SportsmanId == sportsManId&& x.EventId == eventId);
        }

        protected override string getId(SportsmanEventDomain obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.SportsmanId}.{obj.Data.EventId}";
        }
    }
}
