using System.Threading.Tasks;
using Abc.Aids.Random;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Domain.Event;
using North.Infra;
using North.Data.Event;
using North.Tests.Aids;

namespace North.Tests.Infra
{
    [TestClass]
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<EventDomain, EventData>, object>
    {
        private EventData data;

        private class testClass : BaseRepository<EventDomain, EventData>
        {
            public testClass(DbContext c, DbSet<EventData> s) : base(c, s) { }

            protected internal override EventDomain toDomainObject(EventData d) => new EventDomain(d);

            protected override async Task<EventData> getData(string id)
            {
                return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string getId(EventDomain entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<NorthDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            var c = new NorthDbContext(options);
            obj = new testClass(c, c.Events);
            data = GetRandom.Object<EventData>();
        }

        [TestMethod]
        public void GetTest()
        {
            var count = GetRandom.UInt8(15, 30);
            var countBefore = obj.Get().GetAwaiter().GetResult().Count;
            for (var i = 0; i < count; i++)
            {
                data = GetRandom.Object<EventData>();
                AddTest();
            }
            Assert.AreEqual(count + countBefore, obj.Get().GetAwaiter().GetResult().Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            AddTest();
        }

        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var expected = obj.Get(data.Id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(data, expected.Data);
            obj.Delete(data.Id).GetAwaiter();
            expected = obj.Get(data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        [TestMethod]
        public void AddTest()
        {
            var expected = obj.Get(data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            obj.Add(new EventDomain(data)).GetAwaiter();
            expected = obj.Get(data.Id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(data, expected.Data);
        }

        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var newData = GetRandom.Object<EventData>();
            newData.Id = data.Id;
            obj.Update(new EventDomain(newData)).GetAwaiter();
            var expected = obj.Get(data.Id).GetAwaiter().GetResult();
            testArePropertyValuesEqual(newData, expected.Data);
        }
    }
}
