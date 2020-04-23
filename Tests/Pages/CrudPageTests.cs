using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Pages;

namespace North.Tests.Pages {

    [TestClass]
    public class CrudPageTests : AbstractPageTests<CrudPage<IEventsRepository, EventDomain, EventView, EventData>,
        BasePage<IEventsRepository, EventDomain, EventView, EventData>>
    {

        private string fixedFilter;
        private string fixedValue;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(db);
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            Assert.AreEqual(null, obj.FixedValue);
            Assert.AreEqual(null, obj.FixedFilter);
        }

        [TestMethod]
        public void ItemTest()
        {
            isProperty(() => obj.Item, x => obj.Item = x);
        }

        [TestMethod]
        public void AddObjectTest()
        {
            var idx = db.list.Count;
            obj.Item = GetRandom.Object<EventView>();
            obj.addObject(fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            testArePropertyValuesEqual(obj.Item, db.list[idx].Data);
        }

        [TestMethod]
        public void UpdateObjectTest()
        {
            GetObjectTest();
            var idx = GetRandom.Int32(0, db.list.Count);
            var itemId = db.list[idx].Data.Id;
            obj.Item = GetRandom.Object<EventView>();
            obj.Item.Id = itemId;
            obj.updateObject(fixedFilter, fixedValue).GetAwaiter();
            testArePropertyValuesEqual(db.list[^1].Data, obj.Item);
        }

        [TestMethod]
        public void GetObjectTest()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);
            for (var i = 0; i < count; i++) AddObjectTest();
            var item = db.list[idx];
            obj.getObject(item.Data.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(count, db.list.Count);
            testArePropertyValuesEqual(item.Data, obj.Item);
        }

        [TestMethod]
        public void DeleteObjectTest()
        {
            AddObjectTest();
            obj.deleteObject(obj.Item.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(0, db.list.Count);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<EventData>();
            var v = obj.toView(new EventDomain(d));
            testArePropertyValuesEqual(d, v);
        }

        [TestMethod]
        public void ToObjectTest()
        {
            var v = GetRandom.Object<EventView>();
            var o = obj.toObject(v);
            testArePropertyValuesEqual(v, o.Data);
        }

    }

}