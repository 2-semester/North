using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Sportsman;

namespace North.Tests.Data.Sportsman
{
    [TestClass]
    public class SportsmanDataTests: SealedClassTests<SportsmanData,NamedEntityData>
    {
        [TestMethod]
        public void DateOfBirthTest()
        {
            isProperty(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
        }
    }
}
