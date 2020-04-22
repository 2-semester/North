using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportsmanEvent;
using North.Infra.SportsmanEvent;

namespace North.Tests.Infra.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventDbContextTests : BaseClassTests<SportsmanEventDbContext, DbContext>
    {

        private DbContextOptions<SportsmanEventDbContext> options;

        private class testClass : SportsmanEventDbContext
        {
            public testClass(DbContextOptions<SportsmanEventDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<SportsmanEventDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new SportsmanEventDbContext(options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            static void testKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
            {
                var key = entity.FindPrimaryKey();

                if (values is null) Assert.IsNull(key);
                else
                    foreach (var v in values)
                    {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
            }

            static void testEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                testKey(entity, values);
            }

            SportsmanEventDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            SportsmanEventDbContext.InitializeTables(builder);
            testEntity<SportsmanEventData>(builder, x => x.SportsmanId, x => x.SportsmanId);
            //eventId ja sportsmanId??
        }

        [TestMethod]
        public void SportsmanEventsTest() =>
            isNullableProperty(obj, nameof(obj.SportsmanEvents), typeof(DbSet<SportsmanEventData>));
    }
}
