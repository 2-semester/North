﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Event;

namespace North.Tests.Data.Event
{
    [TestClass]
    public class EventDataTests: SealedClassTests<EventData,DefinedEntityData>
    {
        [TestMethod]
        public void EventDateTest()
        {
            isProperty(() => obj.EventDate, x => obj.EventDate = x);
        }
        [TestMethod]
        public void SportCategoryIdTest()
        {
            isNullableProperty(() => obj.SportCategoryId, x => obj.SportCategoryId = x);
        }
        [TestMethod]
        public void TypeIdTest()
        {
            isNullableProperty(() => obj.TypeId, x => obj.TypeId = x);
        }
        [TestMethod]
        public void OrganizationIdTest()
        {
            isNullableProperty(() => obj.OrganizationId, x => obj.OrganizationId = x);
        }
        [TestMethod]
        public void EventListIdTest()
        {
            isNullableProperty(() => obj.EventListId, x => obj.EventListId = x);
        }
        [TestMethod]
        public void LocationIdTest()
        {
            isNullableProperty(() => obj.LocationId, x => obj.LocationId = x);
        }
    }
}
