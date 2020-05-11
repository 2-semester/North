using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "North.Infra";

        protected override string Namespace(string name) { return $"{assembly}.Areas.{name}"; }

        [TestMethod] public void IsEventTested() { isAllTested(assembly, Namespace("Event")); }
        [TestMethod] public void IsEventListTested() { isAllTested(assembly, Namespace("EventList")); }
        [TestMethod] public void IsOrganizationTested() { isAllTested(assembly, Namespace("Organization")); }
        [TestMethod] public void IsSportsmanTested() { isAllTested(assembly, Namespace("Sportsman")); }
        [TestMethod] public void IsSportsmanEventTested() { isAllTested(assembly, Namespace("SportsmanEvent")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Soft")); }
    }
}
