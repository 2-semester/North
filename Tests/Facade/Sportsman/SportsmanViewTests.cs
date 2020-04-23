using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;
using North.Facade.Sportsman;

namespace North.Tests.Facade.Sportsman
{
    class SportsmanViewTests : SealedClassTests<SportsmanView, NamedView>
    {
        [TestMethod]
        public void DateOfBirthTest() => isProperty(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
    }
}
