using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids{
    [TestClass]
    public class WebServiceTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(WebService);

        [TestMethod]
        public void LoadTest()
        {
            const string source1 = "https://docs.microsoft.com/";

            var webpage = new WebClient();

            Assert.AreEqual(webpage.DownloadString(source1), WebService.Load(source1));
        }
    }
}