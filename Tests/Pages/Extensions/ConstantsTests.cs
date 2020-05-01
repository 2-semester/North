using Microsoft.VisualStudio.TestTools.UnitTesting;
using Constants = North.Pages.Extensions.Constants;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class ConstantsTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(Constants);
        }

        [TestMethod] public void UnspecifiedTest()=> Assert.AreEqual("Määramata", Constants.Unspecified);
        [TestMethod] public void CreateNewLinkTitleTest() => Assert.AreEqual("Loo uus", Constants.CreateNewLinkTitle);
        [TestMethod] public void EditLinkTitleTest() => Assert.AreEqual("Muuda", Constants.EditLinkTitle);
        [TestMethod] public void DetailsLinkTitleTest() => Assert.AreEqual("Lisainfo", Constants.DetailsLinkTitle);
        [TestMethod] public void DeleteLinkTitleTest() => Assert.AreEqual("Kustuta", Constants.DeleteLinkTitle);
    }
}
