using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportCategoryType;
using North.Infra.SportCategoryType;

namespace North.Tests.Infra.SportCategoryType
{
    [TestClass]
    public class SportCategoryTypeDbContextTests : BaseClassTests<SportCategoryTypeDbContext, DbContext>
    {

        private DbContextOptions<SportCategoryTypeDbContext> options;

        private class testClass : SportCategoryTypeDbContext
        {

            public testClass(DbContextOptions<SportCategoryTypeDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<SportCategoryTypeDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new SportCategoryTypeDbContext(options);
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

            SportCategoryTypeDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            SportCategoryTypeDbContext.InitializeTables(builder);
            testEntity<SportCategoryTypeData>(builder);
        }

        [TestMethod]
        public void SportCategoryTypesTest() =>
            isNullableProperty(obj, nameof(obj.SportCategoryTypes), typeof(DbSet<SportCategoryTypeData>));
    }
}
