using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.SportCategory;
using North.Domain.SportCategory;
using North.Infra;
using North.Infra.SportCategory;

namespace North.Tests.Infra.SportCategory
{
    [TestClass]
    public class SportCategoriesRepositoryTests : RepositoryTests<SportCategoriesRepository, SportCategoryDomain, SportCategoryData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportCategoryDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SportCategoryDbContext(options);
            dbSet = ((SportCategoryDbContext)db).SportCategories;
            obj = new SportCategoriesRepository((SportCategoryDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<SportCategoryDomain, SportCategoryData>);
        }

        protected override string getId(SportCategoryData d) => d.Id;

        protected override SportCategoryDomain getObject(SportCategoryData d) => new SportCategoryDomain(d);

        protected override void setId(SportCategoryData d, string id) => d.Id = id;
    }
}
