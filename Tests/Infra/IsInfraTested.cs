using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "North.Infra";

        protected override string Namespace(string name) { return $"{assembly}.{name}"; }

        [TestMethod] public void IsEventTested() { isAllTested(assembly, Namespace("Event")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Infra")); }
    }
}
