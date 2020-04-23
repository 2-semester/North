using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Event;
using North.Data.EventList;
using North.Domain.Event;
using North.Domain.EventList;
using North.Facade.Event;
using North.Facade.EventList;
using North.Pages;

namespace North.Tests.Pages {

    [TestClass]
    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IEventsRepository, EventDomain, EventView, EventData>
    {

        internal testRepository db;
        internal class testClass : CommonPage<IEventsRepository, EventDomain, EventView, EventData>
        {

            protected internal testClass(IEventsRepository r) : base(r)
            {
                PageTitle = "Üritused";
            }

            public override string ItemId => Item is null ? string.Empty : Item.GetId();

            protected internal override string getPageUrl() => "/Event/Events";

            protected internal override EventDomain toObject(EventView view) => EventViewFactory.Create(view);

            protected internal override EventView toView(EventDomain obj) => EventViewFactory.Create(obj);

        }

        internal class testRepository : baseTestRepositoryForUniqueEntity<EventDomain, EventData>, IEventsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new testRepository();
        }

    }

}