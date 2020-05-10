﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Tests.Aids;

namespace North.Tests
{
    public class BaseTests
    {
        private const string notTested = "<{0}> is not tested";
        private const string notSpecified = "Class is not specified";
        private List<string> members { get; set; }
        protected Type type;
        protected string typeName => getName();

        private string getName()
        {
            var s = type.Name;
            var index = s.IndexOf("`", StringComparison.Ordinal);
            if (index > -1) s = s.Substring(0, index);

            return s;
        }

        [TestMethod]
        public virtual void IsTested()
        {
            if (type == null) Assert.Inconclusive(notSpecified);
            var m = GetClass.Members(type, PublicBindingFlagsFor.DeclaredMembers);
            members = m.Select(e => e.Name).ToList();
            removeTested();

            if (members.Count == 0) return;
            Assert.Fail(notTested, members[0]);
        }
        [TestMethod]
        public virtual void IsSpecifiedClassTested()
        {
            if (type == null) Assert.Inconclusive(notSpecified);
            var className = GetType().Name;
            Assert.IsTrue(className.StartsWith(typeName));
        }

        private void removeTested()
        {
            var tests = GetType().GetMembers().Select(e => e.Name).ToList();
            for (var i = members.Count; i > 0; i--)
            {
                var m = members[i - 1] + "Test";
                var isTested = tests.Find(o => o == m);

                if (String.IsNullOrEmpty(isTested)) continue;
                members.RemoveAt(i - 1);
            }
        }

        protected static void testArePropertyValuesEqual(object obj1, object obj2)
        {
            foreach (var property in obj1.GetType().GetProperties())
            {
                var name = property.Name;
                var p = obj2.GetType().GetProperty(name);
                Assert.IsNotNull(p,$"No property with name '{name}' found.");
                var expected = property.GetValue(obj1);
                var actual = p.GetValue(obj2);
                Assert.AreEqual(expected, actual, $"For property'{name}'.");
            }
        }
        protected static void testArePropertiesNotEqual(object obj1, object obj2)
        {
            foreach (var property in obj1.GetType().GetProperties())
            {
                var name = property.Name;
                var p = obj2.GetType().GetProperty(name);
                Assert.IsNotNull(p, $"No property with name '{name}' found.");
                var expected = property.GetValue(obj1);
                var actual = p.GetValue(obj2);

                if (expected != actual) return;
            }

            Assert.Fail("All properties are same");
        }
    }
}