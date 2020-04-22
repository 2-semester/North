using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Location;
using North.Infra.Location;

namespace North.Tests.Infra.Location
{
    [TestClass]
    public class LocationDbContextTests : BaseClassTests<LocationDbContext, DbContext>
    {

        private DbContextOptions<LocationDbContext> options;

        private class testClass : LocationDbContext
        {

            public testClass(DbContextOptions<LocationDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<LocationDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new LocationDbContext(options);
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

            LocationDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            LocationDbContext.InitializeTables(builder);
            testEntity<LocationData>(builder, x => x.EventId, x => x.EventId);
            //eventId ja EventListId peaks olema testitud vist
        }

        [TestMethod]
        public void LocationsTest() =>
            isNullableProperty(obj, nameof(obj.Locations), typeof(DbSet<LocationData>));
    }
}
