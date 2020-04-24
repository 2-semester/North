using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Location;
using North.Data.Organization;
using North.Data.SportCategory;
using North.Data.SportCategoryType;
using North.Data.Sportsman;
using North.Data.SportsmanEvent;
using North.Infra;

namespace North.Tests.Infra
{
    [TestClass]
    public class NorthDbContextTests : BaseClassTests<NorthDbContext, DbContext>
    {

        private DbContextOptions<NorthDbContext> options;

        private class testClass : NorthDbContext
        {

            public testClass(DbContextOptions<NorthDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<NorthDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new NorthDbContext(options);
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

            NorthDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            NorthDbContext.InitializeTables(builder);
            testEntity<EventData>(builder, x => x.TypeId, x => x.TypeId);
            testEntity<EventListData>(builder, x => x.EventId);
            testEntity<LocationData>(builder);
            testEntity<OrganizationData>(builder);
            testEntity<SportCategoryData>(builder);
            testEntity<SportCategoryTypeData>(builder);
            testEntity<SportsmanData>(builder);
            testEntity<SportsmanEventData>(builder, x => x.SportsmanId, x => x.SportsmanId);

        }

        [TestMethod]
        public void EventsTest() =>
            isNullableProperty(obj, nameof(obj.Events), typeof(DbSet<EventData>));
    }
}
