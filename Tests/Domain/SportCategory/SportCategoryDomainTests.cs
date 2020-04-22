using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.SportCategory;
using North.Domain.Common;
using North.Domain.SportCategory;

namespace North.Tests.Domain.SportCategory
{
    [TestClass]
    public class SportCategoryDomainTests : SealedClassTests<SportCategoryDomain,Entity<SportCategoryData>> { }
}
