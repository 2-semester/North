﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;
using North.Facade.EventList;

namespace North.Tests.Facade.EventList
{
    [TestClass]
    public class EventListViewTests : SealedClassTests<EventListView, NamedView>
    {
        [TestMethod]
        public void EventIdTest() => isProperty(() => obj.EventId, x => obj.EventId = x);
    }
}
