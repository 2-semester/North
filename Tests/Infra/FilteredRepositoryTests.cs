using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Domain.Event;
using North.Infra;
using North.Data.Event;
using North.Infra.Event;

namespace North.Tests.Infra
{
    [TestClass]
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<EventDomain, EventData>,
        SortedRepository<EventDomain, EventData>>
    {

        private class testClass : FilteredRepository<EventDomain, EventData>
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

            var options = new DbContextOptionsBuilder<EventDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new EventDbContext(options);
            obj = new testClass(c, c.Events);
        }

        [TestMethod]
        public void SearchStringTest()
            => isNullableProperty(() => obj.SearchString, x => obj.SearchString = x);

        [TestMethod]
        public void FixedFilterTest()
            => isNullableProperty(() => obj.FixedFilter, x => obj.FixedFilter = x);

        [TestMethod]
        public void FixedValueTest()
            => isNullableProperty(() => obj.FixedValue, x => obj.FixedValue = x);

        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var sql = obj.createSqlQuery();
            Assert.IsNotNull(sql);
        }

        [TestMethod]
        public void AddFixedFilteringTest()
        {
            var sql = obj.createSqlQuery();
            var fixedFilter = GetMember.Name<EventData>(x => x.Definition);
            obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            obj.FixedValue = fixedValue;
            var sqlNew = obj.addFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateFixedWhereExpressionTest()
        {
            var properties = typeof(EventData).GetProperties();
            var idx = GetRandom.Int32(0, properties.Length);
            var p = properties[idx];
            obj.FixedFilter = p.Name;
            var fixedValue = GetRandom.String();
            obj.FixedValue = fixedValue;
            var e = obj.createFixedWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            var expected = p.Name;
            if (p.PropertyType != typeof(string))
                expected += ".ToString()";
            expected += $" == \"{fixedValue}\")";
            Assert.IsTrue(s.Contains(expected));
        }

        [TestMethod]
        public void CreateFixedWhereExpressionOnFixedFilterNullTest()
        {
            Assert.IsNull(obj.createFixedWhereExpression());
            obj.FixedValue = GetRandom.String();
            obj.FixedFilter = GetRandom.String();
            Assert.IsNull(obj.createFixedWhereExpression());
        }

        [TestMethod]
        public void AddFilteringTest()
        {
            var sql = obj.createSqlQuery();
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var sqlNew = obj.addFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateWhereExpressionTest()
        {
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var e = obj.createWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            foreach (var p in typeof(EventData).GetProperties())
            {
                var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{searchString}\")";
                Assert.IsTrue(s.Contains(expected));
            }
        }

        [TestMethod]
        public void CreateWhereExpressionWithNullSearchStringTest()
        {
            obj.SearchString = null;
            var e = obj.createWhereExpression();
            Assert.IsNull(e);
        }
    }
}
