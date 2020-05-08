using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.Sportsman;
using North.Domain.Sportsman;
using North.Facade.Sportsman;

namespace North.Tests.Facade.Sportsman
{
    [TestClass]
    public class SportsmanViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(SportsmanViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<SportsmanView>();
            var data = SportsmanViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<SportsmanData>();
            var view = SportsmanViewFactory.Create(new SportsmanDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}