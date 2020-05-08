﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids 
{
    [TestClass]
    public class IsReadOnlyTests : BaseTests
    {
        private class testClass
        {
            public string A;
            public readonly string B = "";
            public testClass() { E = ""; }
            public string C { get; set; }
            public string D { get; } = "";
            public string E { get; private set; }
        }
        private testClass o;

        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(IsReadOnly);
            o = new testClass { A = "", C = "" };
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Assert.IsNotNull(o.A);
            Assert.IsNotNull(o.B);
            Assert.IsNotNull(o.C);
            Assert.IsNotNull(o.D);
            Assert.IsNotNull(o.E);
        }
        [TestMethod]
        public void FieldTest()
        {
            Assert.IsFalse(IsReadOnly.Field<testClass>("A"));
            Assert.IsTrue(IsReadOnly.Field<testClass>("B"));
            Assert.IsFalse(IsReadOnly.Field<testClass>("C"));
            Assert.IsFalse(IsReadOnly.Field<testClass>("D"));
            Assert.IsFalse(IsReadOnly.Field<testClass>("E"));
        }
        [TestMethod]
        public void PropertyTest()
        {
            Assert.IsFalse(IsReadOnly.Property<testClass>("A"));
            Assert.IsFalse(IsReadOnly.Property<testClass>("B"));
            Assert.IsFalse(IsReadOnly.Property<testClass>("C"));
            Assert.IsTrue(IsReadOnly.Property<testClass>("D"));
            Assert.IsFalse(IsReadOnly.Property<testClass>("E"));
        }
    }
}


