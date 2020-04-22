using North.Data.SportCategoryType;
using North.Domain.Common;

namespace North.Domain.SportCategoryType
{
    public sealed class SportCategoryTypeDomain : Entity<SportCategoryTypeData>
    {
        public SportCategoryTypeDomain() : this(null) { }
        public SportCategoryTypeDomain(SportCategoryTypeData data) : base(data) { }
    }
}
