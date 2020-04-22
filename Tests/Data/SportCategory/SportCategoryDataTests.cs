using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.SportCategory;

namespace North.Tests.Data.SportCategory
{
    [TestClass]
    public class SportCategoryDataTests : SealedClassTests<SportCategoryData,NamedEntityData>
    {
        [TestMethod]
        public void SportCategoryIdTest()
        {
            isNullableProperty(() => obj.SportCategoryId, x => obj.SportCategoryId = x);
        }
    }
}
