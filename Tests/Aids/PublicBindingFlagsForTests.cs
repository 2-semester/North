using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Aids {

    [TestClass]
    public class PublicBindingFlagsForTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(PublicBindingFlagsForTests);
            testType = typeof(testClass);
        }

        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        private Type testType;

        internal class testClass
        {
            public void Aaa() => bbb();

            private void bbb() { }

            public static void Ccc() => ddd();

            private static void ddd() { }
        }

        [TestMethod]
        public void AllTest()
            => testMembers(i | s | p, PublicBindingFlagsForTests.All, 7);

        [TestMethod]
        public void InstanceTest()
            => testMembers(i | p, PublicBindingFlagsForTests.Instance, 6);

        [TestMethod]
        public void StaticTest()
            => testMembers(s | p, PublicBindingFlagsForTests.Static, 1);

        [TestMethod]
        public void DeclaredTest()
            => testMembers(d | i | s | p, PublicBindingFlagsForTests.Declared, 3);

        private void testMembers(BindingFlags expected, BindingFlags actual,
            int membersCount)
        {
            var a = testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }
    }
}




