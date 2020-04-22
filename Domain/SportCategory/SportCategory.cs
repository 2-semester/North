using North.Data.SportCategory;
using North.Domain.Common;

namespace North.Domain.SportCategory
{
    public sealed class SportCategory : Entity<SportCategoryData>
    {
        public SportCategory() : this(null) { }
        public SportCategory(SportCategoryData data) : base(data) { }
    }
}
