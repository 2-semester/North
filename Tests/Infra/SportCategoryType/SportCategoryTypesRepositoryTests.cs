using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;
using North.Infra;
using North.Infra.SportCategoryType;

namespace North.Tests.Infra.SportCategoryType
{
    [TestClass]
    public class SportCategoryTypesRepositoryTests : RepositoryTests<SportCategoryTypesRepository, SportCategoryTypeDomain, SportCategoryTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportCategoryTypeDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SportCategoryTypeDbContext(options);
            dbSet = ((SportCategoryTypeDbContext)db).SportCategoryTypes;
            obj = new SportCategoryTypesRepository((SportCategoryTypeDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<SportCategoryTypeDomain, SportCategoryTypeData>);
        }

        protected override string getId(SportCategoryTypeData d) => d.Id;

        protected override SportCategoryTypeDomain getObject(SportCategoryTypeData d) => new SportCategoryTypeDomain(d);

        protected override void setId(SportCategoryTypeData d, string id) => d.Id = id;
    }
}
