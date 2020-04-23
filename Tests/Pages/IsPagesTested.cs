using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Pages
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {
        private const string assembly = "North.Pages";

        protected override string Namespace(string name) { return $"{assembly}.{name}"; }
        [TestMethod] public void IsEventTested() { isAllTested(assembly, Namespace("Event")); }
        [TestMethod] public void IsExtensionsTested() { isAllTested(assembly, Namespace("Extensions")); }
        [TestMethod] public void IsEventListTested() { isAllTested(assembly, Namespace("EventList")); }
        [TestMethod] public void IsOrganizationTested() { isAllTested(assembly, Namespace("Organization")); }
        [TestMethod] public void IsSportCategoryTypeTested() { isAllTested(assembly, Namespace("SportCategoryType")); }
        [TestMethod] public void IsSportsmanTested() { isAllTested(assembly, Namespace("Sportsman")); }
        [TestMethod] public void IsSportsmanEventTested() { isAllTested(assembly, Namespace("SportsmanEvent")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Pages")); }

    }
}
