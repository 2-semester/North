using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Organization;
using North.Infra.Organization;

namespace North.Tests.Infra.Organization
{

    [TestClass]
    public class OrganizationDbContextTests : BaseClassTests<OrganizationDbContext, DbContext>
    {

        private DbContextOptions<OrganizationDbContext> options;

        private class testClass : OrganizationDbContext
        {

            public testClass(DbContextOptions<OrganizationDbContext> o) : base(o) { }

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
            options = new DbContextOptionsBuilder<OrganizationDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new OrganizationDbContext(options);
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

            OrganizationDbContext.InitializeTables(null);
            var o = new testClass(options);
            var builder = o.RunOnModelCreating();
            OrganizationDbContext.InitializeTables(builder);
            testEntity<OrganizationData>(builder);
        }

        [TestMethod]
        public void OrganizationsTest() =>
            isNullableProperty(obj, nameof(obj.Organizations), typeof(DbSet<OrganizationData>));
    }
}
