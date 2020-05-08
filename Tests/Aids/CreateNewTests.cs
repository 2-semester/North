using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids
{
    [TestClass]
    public class CreateNewTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(CreateNew);

        [TestMethod]
        public void InstanceTest()
        {
            var o1 = CreateNew.Instance<testClass1>();
            var o2 = CreateNew.Instance<testClass1>();
            Assert.IsInstanceOfType(o1, typeof(testClass1));
            Assert.AreNotEqual(o1.S, o2.S);
            Assert.AreNotEqual(o1.I, o2.I);
        }

        [TestMethod]
        public void CreateDefaultTest()
        {
            var o1 = CreateNew.Instance<testClass2>();
            var o2 = CreateNew.Instance<testClass2>();
            Assert.IsInstanceOfType(o1, typeof(testClass2));
            Assert.AreNotEqual(o1.S, o2.S);
            Assert.AreNotEqual(o1.I, o2.I);
        }

        [TestMethod]
        public void CreateStringTest()
        {
            var s = CreateNew.Instance<string>();
            Assert.IsInstanceOfType(s, typeof(string));
        }

        private class testClass1
        {
            public testClass1(int i, string s)
            {
                S = s;
                I = i;
            }

            public int I { get; }
            public string S { get; }
        }

        private class testClass2
        {
            public int I { get; } = GetRandomTests.Int32();
            public string S { get; } = GetRandomTests.String();
        }
    }
}
