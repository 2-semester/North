using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.SportCategoryType;
using North.Domain.Common;
using North.Domain.SportCategoryType;

namespace North.Tests.Domain.SportCategoryType
{
    [TestClass]
    public class SportCategoryTypeDomainTests: SealedClassTests<SportCategoryTypeDomain,Entity<SportCategoryTypeData>> {}
}
