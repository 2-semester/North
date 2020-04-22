using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportCategory;
using North.Infra.SportCategory;

namespace North.Tests.Infra.SportCategory
{
    [TestClass]
    public class SportCategoryDbContextTests : BaseClassTests<SportCategoryDbContext, DbContext>
    {

        private DbContextOptions<SportCategoryDbContext> options;

        private class testClass : SportCategoryDbContext
        {

            public testClass(DbContextOptions<SportCategoryDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<SportCategoryDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new SportCategoryDbContext(options);
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

            SportCategoryDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            SportCategoryDbContext.InitializeTables(builder);
            testEntity<SportCategoryData>(builder, x => x.SportCategoryId, x => x.SportCategoryId);
        }

        [TestMethod]
        public void SportCategoriesTest() =>
            isNullableProperty(obj, nameof(obj.SportCategories), typeof(DbSet<SportCategoryData>));
    }
}
