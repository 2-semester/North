using North.Data.SportCategory;
using North.Domain.Common;

namespace North.Domain.SportCategory
{
    public sealed class SportCategoryDomain : Entity<SportCategoryData>
    {
        public SportCategoryDomain() : this(null) { }
        public SportCategoryDomain(SportCategoryData data) : base(data) { }
    }
}
