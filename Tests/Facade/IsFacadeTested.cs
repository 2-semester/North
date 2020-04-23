using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        private const string assembly = "North.Facade";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsCommonTested() { isAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsEventTested() { isAllTested(assembly, Namespace("Event")); }
        [TestMethod] public void IsEventListTested() { isAllTested(assembly, Namespace("EventList")); }
        [TestMethod] public void IsOrganizationTested() { isAllTested(assembly, Namespace("Organization")); }
        [TestMethod] public void IsSportCategoryTypeTested() { isAllTested(assembly, Namespace("SportCategoryType")); }
        [TestMethod] public void IsSportsmanTested() { isAllTested(assembly, Namespace("Sportsman")); }
        [TestMethod] public void IsSportsmanEventTested() { isAllTested(assembly, Namespace("SportsmanEvent")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Facade")); }
    }
}
