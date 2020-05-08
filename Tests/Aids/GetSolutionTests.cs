using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids {

    [TestClass]
    public class GetSolutionTests : BaseTests
    {

        private static string assemblyName = "North.Aids";
        private const string dummyName = "bla-bla";

        [TestInitialize] public void TestInitialize() => type = typeof(GetSolution);

        [TestMethod]
        public void DomainTest()
        {
            var expected = AppDomain.CurrentDomain;
            var actual = GetSolution.Domain;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssembliesTest()
        {
            var expected = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var actual = GetSolution.Assemblies;
            foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
            Assert.AreEqual(expected.Count, actual.Count);
        }

        [TestMethod]
        public void AssemblyByNameTest()
        {
            Assert.IsNull(GetSolution.AssemblyByName(dummyName));
            var assembly = GetSolution.AssemblyByName(assemblyName);
            Assert.IsTrue(assembly.FullName.StartsWith(assemblyName));
        }

        [TestMethod]
        public void TypesForAssemblyTest()
        {
            var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            var actual = GetSolution.TypesForAssembly(dummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<Type>));
            actual = GetSolution.TypesForAssembly(assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
        }

        [TestMethod]
        public void TypeNamesForAssemblyTest()
        {
            var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            var actual = GetSolution.TypeNamesForAssembly(dummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<string>));
            actual = GetSolution.TypeNamesForAssembly(assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected)
                Assert.IsTrue(actual.Contains(e.FullName));
        }
        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(nameof(North), GetSolution.Name);
        }
    }

}



