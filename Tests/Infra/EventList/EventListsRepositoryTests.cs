using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Event;
using North.Data.EventList;
using North.Domain.Event;
using North.Domain.EventList;
using North.Infra;
using North.Infra.EventList;

namespace North.Tests.Infra.EventList
{
    [TestClass]
    public class EventListsRepositoryTests : RepositoryTests<EventListsRepository, EventListDomain, EventListData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<EventListDbContext>()
                .UseInMemoryDatabase("TestDb") //loob mälus andmebaasi
                .Options;
            db = new EventListDbContext(options);
            dbSet = ((EventListDbContext)db).EventLists;
            obj = new EventListsRepository((EventListDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<EventDomain, EventData>);
        }

        protected override string getId(EventListData d) => d.Id;

        protected override EventListDomain getObject(EventListData d) => new EventListDomain(d);

        protected override void setId(EventListData d, string id) => d.Id = id;
    }
}
