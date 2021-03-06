﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.Sportsman;
using North.Domain.Sportsman;
using North.Facade.Sportsman;
using North.Pages;
using North.Pages.Sportsman;

namespace North.Tests.Pages.Sportsman
{
    [TestClass]
    public class SportsmenPageTests : AbstractClassTests<SportsmenPage,
        CommonPage<ISportsmenRepository, SportsmanDomain, SportsmanView, SportsmanData>>
    {
        private class testClass : SportsmenPage
        {
            internal testClass(ISportsmenRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<SportsmanDomain, SportsmanData>, ISportsmenRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new testRepository();
            obj = new testClass(r);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<SportsmanView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Sportlased", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Sportsman/Sportsmen", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<SportsmanView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<SportsmanData>();
            var view = obj.toView(new SportsmanDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
