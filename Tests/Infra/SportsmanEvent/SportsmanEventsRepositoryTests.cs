using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;
using North.Infra;
using North.Infra.SportsmanEvent;

namespace North.Tests.Infra.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventsRepositoryTests : RepositoryTests<SportsmanEventsRepository, SportsmanEventDomain, SportsmanEventData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<NorthDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new NorthDbContext(options);
            dbSet = ((NorthDbContext)db).SportsmanEvents;
            obj = new SportsmanEventsRepository((NorthDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(PaginatedRepository<SportsmanEventDomain, SportsmanEventData>);
        }

        protected override string getId(SportsmanEventData d) => $"{d.SportsmanId}.{d.EventId}";

        protected override SportsmanEventDomain getObject(SportsmanEventData d) => new SportsmanEventDomain(d);

        protected override void setId(SportsmanEventData d, string id)
        {
            var sportsmanId = GetString.Head(id);
            var eventId = GetString.Tail(id);
            d.SportsmanId = sportsmanId;
            d.EventId = eventId;
        }
    }
}
