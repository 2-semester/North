﻿using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;

namespace North.Infra.SportsmanEvent
{
    class SportsmanEventsRepository : UniqueEntityRepository<SportsmanEventDomain, SportsmanEventData>, ISportsmanEventsRepository
    {
        public SportsmanEventsRepository(SportsmanEventDbContext c) : base(c, c.SportsmanEvents) { }

        protected internal override SportsmanEventDomain toDomainObject(SportsmanEventData d) => new SportsmanEventDomain(d);
    }
}
