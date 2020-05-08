using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Domain.Event;
using North.Infra;
using North.Data.Event;

namespace North.Tests.Infra
{
    [TestClass]
    public class PaginatedRepositoryTests :
        AbstractClassTests<PaginatedRepository<EventDomain, EventData>, FilteredRepository<EventDomain, EventData>>
    {
        private class testClass : PaginatedRepository<EventDomain, EventData>
        {
            public testClass(DbContext c, DbSet<EventData> s) : base(c, s) { }

            protected internal override EventDomain toDomainObject(EventData d) => new EventDomain(d);

            protected override async Task<EventData> getData(string id)
                => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

            protected override string getId(EventDomain entity) => entity?.Data?.Id;
        }
        private byte count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<NorthDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new NorthDbContext(options);
            obj = new testClass(c, c.Events);
            count = GetRandomTests.UInt8(20, 40);
            foreach (var p in c.Events)
                c.Entry(p).State = EntityState.Deleted;
            addItems();
        }

        [TestMethod]
        public void PageIndexTest()
        {
            isProperty(() => obj.PageIndex, x => obj.PageIndex = x);
        }

        [TestMethod]
        public void TotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)obj.PageSize);
            var totalPagesCount = obj.TotalPages;
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void HasNextPageTest()
        {
            void testNextPage(int pageIndex, bool expected)
            {
                obj.PageIndex = pageIndex;
                var actual = obj.HasNextPage;
                Assert.AreEqual(expected, actual);
            }
            testNextPage(0, true);
            testNextPage(1, true);
            testNextPage(GetRandomTests.Int32(2, obj.TotalPages - 1), true);
            testNextPage(obj.TotalPages, false);
        }

        [TestMethod]
        public void HasPreviousPageTest()
        {
            void testPreviousPage(int pageIndex, bool expected)
            {
                obj.PageIndex = pageIndex;
                var actual = obj.HasPreviousPage;
                Assert.AreEqual(expected, actual);
            }
            testPreviousPage(0, false);
            testPreviousPage(1, false);
            testPreviousPage(2, true);
            testPreviousPage(GetRandomTests.Int32(2, obj.TotalPages), true);
            testPreviousPage(obj.TotalPages, true);
        }

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.AreEqual(5, obj.PageSize);
            isProperty(() => obj.PageSize, x => obj.PageSize = x);
        }

        [TestMethod]
        public void GetTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)obj.PageSize);
            var totalPagesCount = obj.getTotalPages(obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void CountTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(count / (double)obj.PageSize);
            var totalPagesCount = obj.CountTotalPages(count, obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void GetItemsCountTest()
        {
            var itemsCount = obj.getItemsCount();
            Assert.AreEqual(count, itemsCount);
        }

        private void addItems()
        {
            for (var i = 0; i < count; i++)
                obj.Add(new EventDomain(GetRandomTests.Object<EventData>())).GetAwaiter();
        }

        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var o = obj.createSqlQuery();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void AddSkipAndTakeTest()
        {
            var sql = obj.createSqlQuery();

            var o = obj.addSkipAndTake(sql);
            Assert.IsNotNull(o);
        }
    }
}
