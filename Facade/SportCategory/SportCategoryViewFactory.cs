using North.Aids;
using North.Data.SportCategory;
using North.Domain.SportCategory;

namespace North.Facade.SportCategory
{
    public static class SportCategoryViewFactory
    {
        public static SportCategoryDomain Create(SportCategoryView view)
        {
            var d = new SportCategoryData();
            Copy.Members(view, d);
            return new SportCategoryDomain(d);
        }


        public static SportCategoryView Create(SportCategoryDomain obj)
        {
            var v = new SportCategoryView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
