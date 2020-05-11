using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace North.Tests.Soft
{
    [TestClass]
  public class IsSoftTested:AssemblyTests
    {
        private const string assembly = "North.Soft";

        protected override string Namespace(string name) { return $"{assembly}.Areas.{name}"; }
        //[TestMethod] public void IsEventTested() { isAllTested(assembly, Namespace("Event.Pages.Events")); }
        //[TestMethod] public void IsEventListTested() { isAllTested(assembly, Namespace("EventList")); }
        //[TestMethod] public void IsOrganizationTested() { isAllTested(assembly, Namespace("Organization")); }
        //[TestMethod] public void IsSportCategoryTypeTested() { isAllTested(assembly, Namespace("SportCategoryType")); }
        //[TestMethod] public void IsSportsmanTested() { isAllTested(assembly, Namespace("Sportsman")); }
        //[TestMethod] public void IsSportsmanEventTested() { isAllTested(assembly, Namespace("SportsmanEvent")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Pages")); }

    }
}

