using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Pages.Extensions;

namespace North.Tests.Pages.Extensions
{
    [TestClass]
    public class DetailsTableForHtmlExtensionTests:BaseTests 
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DetailsTableForHtmlExtension);
        }

        [TestMethod]
        public void DetailsTableForTest()
        {
            Assert.Inconclusive();
        }
    }
}
