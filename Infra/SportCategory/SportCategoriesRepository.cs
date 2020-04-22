using North.Data.SportCategory;
using North.Domain.SportCategory;

namespace North.Infra.SportCategory
{
    public sealed class SportCategoriesRepository : UniqueEntityRepository<SportCategoryDomain, SportCategoryData>, ISportCategoriesRepository
    {
        public SportCategoriesRepository(SportCategoryDbContext c) : base(c, c.SportCategories) { }

        protected internal override SportCategoryDomain toDomainObject(SportCategoryData d) => new SportCategoryDomain(d);
    }
}
