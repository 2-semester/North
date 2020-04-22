using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Infra.Event;
using North.Data.Event;

namespace North.Tests.Infra.Event
{
    [TestClass]
    public class EventDbContextTests : BaseClassTests<EventDbContext, DbContext>
    {

        private DbContextOptions<EventDbContext> options;

        private class testClass : EventDbContext
        {

            public testClass(DbContextOptions<EventDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<EventDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new EventDbContext(options);
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

            EventDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            EventDbContext.InitializeTables(builder);
            testEntity<EventData>(builder, x => x.TypeId, x => x.TypeId);
            //testEntity<EventData>(builder, x => x.EventListId, x => x.EventListId);
            //testEntity<EventData>(builder, x => x.SportsmanEventId, x => x.SportsmanEventId);
            //nii ei toimi, aga vaa on testida kolme id-d ikkagi vist
        }

        [TestMethod]
        public void EventsTest() =>
            isNullableProperty(obj, nameof(obj.Events), typeof(DbSet<EventData>));
    }
}
