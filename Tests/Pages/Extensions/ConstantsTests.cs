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

        [TestMethod] public void UnspecifiedTest()=> Assert.AreEqual("Unspecified",Constants.Unspecified);
        [TestMethod] public void CreateNewLinkTitleTest() => Assert.AreEqual("Create New", Constants.CreateNewLinkTitle);
        [TestMethod] public void EditLinkTitleTest() => Assert.AreEqual("Edit", Constants.EditLinkTitle);
        [TestMethod] public void DetailsLinkTitleTest() => Assert.AreEqual("Details", Constants.DetailsLinkTitle);
        [TestMethod] public void DeleteLinkTitleTest() => Assert.AreEqual("Delete", Constants.DeleteLinkTitle);
    }
}
