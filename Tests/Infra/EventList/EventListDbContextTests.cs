﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.EventList;
using North.Infra.EventList;

namespace North.Tests.Infra.EventList
{
    [TestClass]
    public class EventListDbContextTests : BaseClassTests<EventListDbContext, DbContext>
    {

        private DbContextOptions<EventListDbContext> options;

        private class testClass : EventListDbContext
        {

            public testClass(DbContextOptions<EventListDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<EventListDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new EventListDbContext(options);
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

            EventListDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            EventListDbContext.InitializeTables(builder);
            testEntity<EventListData>(builder, x => x.EventId, x => x.EventId);
            //siin ka jama
        }

        [TestMethod]
        public void EventListsTest() =>
            isNullableProperty(obj, nameof(obj.EventLists), typeof(DbSet<EventListData>));
    }
}