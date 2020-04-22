using North.Aids;
using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;

namespace North.Facade.SportCategoryType
{
    public static class SportCategoryTypeViewFactory
    {
        public static SportCategoryTypeDomain Create(SportCategoryTypeView view)
        {
            var d = new SportCategoryTypeData();
            Copy.Members(view, d);
            return new SportCategoryTypeDomain(d);
        }

        public static SportCategoryTypeView Create(SportCategoryTypeDomain obj)
        {
            var v = new SportCategoryTypeView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
