using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Event;
using North.Domain.Event;
using North.Infra;
using North.Infra.Event;

namespace North.Tests.Infra.Event
{
    [TestClass]
    public class EventsRepositoryTests : RepositoryTests<EventsRepository, EventDomain, EventData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<EventDbContext>()
                .UseInMemoryDatabase("TestDb") //loob mälus andmebaasi
                .Options;
            db = new EventDbContext(options);
            dbSet = ((EventDbContext) db).Events;
            obj = new EventsRepository((EventDbContext) db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<EventDomain, EventData>);
        }

        protected override string getId(EventData d) => d.Id;

        protected override EventDomain getObject(EventData d) => new EventDomain(d);

        protected override void setId(EventData d, string id) => d.Id = id;
    }
}