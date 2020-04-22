using North.Data.SportCategoryType;
using North.Domain.Common;

namespace North.Domain.SportCategoryType
{
    public sealed class SportCategoryType : Entity<SportCategoryTypeData>
    {
        public SportCategoryType() : this(null) { }
        public SportCategoryType(SportCategoryTypeData data) : base(data) { }
    }
}
