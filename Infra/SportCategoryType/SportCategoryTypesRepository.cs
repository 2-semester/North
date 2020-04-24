using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;

namespace North.Infra.SportCategoryType
{
    public sealed class SportCategoryTypesRepository : UniqueEntityRepository<SportCategoryTypeDomain, SportCategoryTypeData>, ISportCategoryTypesRepository
    {
        public SportCategoryTypesRepository(NorthDbContext c) : base(c, c.SportCategoryTypes) { }

        protected internal override SportCategoryTypeDomain toDomainObject(SportCategoryTypeData d) => new SportCategoryTypeDomain(d);
    }
}
