using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Pages;
using North.Tests.Aids;

namespace North.Tests.Pages {

    [TestClass] public class PaginatedPageTests :
        AbstractPageTests<PaginatedPage<IEventsRepository, EventDomain, EventView, EventData>,
        CrudPage<IEventsRepository, EventDomain, EventView, EventData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
        }

        [TestMethod] public void ItemsTest() {
            isReadOnlyProperty(obj, nameof(obj.Items), null);
        }

        [TestMethod] public void PageIndexTest() {
            var i = GetRandomTests.UInt8(3);
            obj.PageIndex = i;
            Assert.AreEqual(i, db.PageIndex);
            Assert.AreEqual(i, obj.PageIndex);
        }

        [TestMethod] public void HasPreviousPageTest() {
            db.HasPreviousPage = GetRandomTests.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasPreviousPage), db.HasPreviousPage);
        }

        [TestMethod] public void HasNextPageTest() {
            db.HasNextPage = GetRandomTests.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasNextPage), db.HasNextPage);
        }

        [TestMethod] public void TotalPagesTest() {
            db.TotalPages = GetRandomTests.UInt8();
            isReadOnlyProperty(obj, nameof(obj.TotalPages), db.TotalPages);
        }

        [TestMethod] public void GetListTest() {
            Assert.IsNull(obj.Items);
            var sortOrder = GetRandomTests.String();
            var currentFilter = GetRandomTests.String();
            var searchString = GetRandomTests.String();
            var fixedFilter = GetRandomTests.String();
            var fixedValue = GetRandomTests.String();
            var pageIndex = GetRandomTests.UInt8();
            obj.getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            Assert.IsNotNull(obj.Items);
            Assert.AreEqual(sortOrder, obj.SortOrder);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(1, obj.PageIndex);
        }

        [TestMethod] public void GetListNoArgumentsTest() {
            var l = obj.getList().GetAwaiter().GetResult();
            Assert.AreEqual(0, l.Count);

            for (var i = 0; i < GetRandomTests.UInt8(); i++) {
                var d = GetRandomTests.Object<EventData>();
                db.Add(new EventDomain(d)).GetAwaiter();
                l = obj.getList().GetAwaiter().GetResult();
                Assert.AreEqual(i + 1, l.Count);
            }
        }

    }

}
