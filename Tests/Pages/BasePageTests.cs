using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Pages;
using North.Tests.Aids;

namespace North.Tests.Pages {

    [TestClass]
    public class BasePageTests : AbstractPageTests<BasePage<IEventsRepository, EventDomain, EventView, EventData>,
        PageModel> {


        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
        }

        [TestMethod] public void FixedValueTest() {
            var s = GetRandomTests.String();
            obj.FixedValue = s;
            Assert.AreEqual(s, db.FixedValue);
            Assert.AreEqual(s, obj.FixedValue);
        }

        [TestMethod] public void FixedFilterTest() {
            var s = GetRandomTests.String();
            obj.FixedFilter = s;
            Assert.AreEqual(s, db.FixedFilter);
            Assert.AreEqual(s, obj.FixedFilter);
        }

        [TestMethod] public void SetFixedFilterTest() {
            var filter = GetRandomTests.String();
            var value = GetRandomTests.String();
            obj.setFixedFilter(filter, value);
            Assert.AreEqual(filter, obj.FixedFilter);
            Assert.AreEqual(value, obj.FixedValue);
        }

        [TestMethod] public void SortOrderTest() {
            var s = GetRandomTests.String();
            obj.SortOrder = s;
            Assert.AreEqual(s, db.SortOrder);
            Assert.AreEqual(s, obj.SortOrder);
        }

        [TestMethod] public void GetSortOrderTest() {
            void test(string sortOrder, string name, bool isDesc) {
                obj.SortOrder = sortOrder;
                var actual = obj.getSortOrder(name);
                var expected = isDesc ? name + "_desc" : name;
                Assert.AreEqual(expected, actual);
            }
            test(null, GetRandomTests.String(), false);
            test(GetRandomTests.String(), GetRandomTests.String(), false);
            var s = GetRandomTests.String();
            test(s, s, true);
            test(s+"_desc", s, false);
        }

        [TestMethod] public void SearchStringTest() {
            var s = GetRandomTests.String();
            obj.SearchString = s;
            Assert.AreEqual(s, db.SearchString);
            Assert.AreEqual(s, obj.SearchString);
        }

        [TestMethod] public void GetSortStringTest() {
            const string page = "xxx/yyy";
            obj.SortOrder = "Name";
            obj.SearchString = "AAA";
            obj.FixedFilter = "BBB";
            obj.FixedValue = "CCC";
            var sortString = obj.GetSortString(x=>x.Name, page);
            var s = "xxx/yyy?sortOrder=Name_desc&currentFilter=AAA&fixedFilter=BBB&fixedValue=CCC";
            Assert.AreEqual(s, sortString);
        }

        [TestMethod] public void GetSearchStringTest() {
            void test(string filter, string searchString, int? pageIndex, bool isFirst) {
                var expectedSearchString = isFirst ? searchString: filter;
                var expectedIndex = isFirst ? 1 : pageIndex;
                var actual = BasePage<IEventsRepository, EventDomain, EventView, EventData>.getSearchString(filter, searchString, ref pageIndex);
                Assert.AreEqual(expectedSearchString, actual);
                Assert.AreEqual(expectedIndex, pageIndex);
            }
            test(GetRandomTests.String(), GetRandomTests.String(), GetRandomTests.UInt8(3), true);
            test(GetRandomTests.String(), null, GetRandomTests.UInt8(3), false);
        }


    }

}
