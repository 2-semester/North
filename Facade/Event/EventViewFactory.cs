using North.Aids;
using North.Data.Event;
using North.Domain.Event;

namespace North.Facade.Event
{
   public static class EventViewFactory
    {
        public static EventDomain Create(EventView view)
        {
            var d = new EventData();
            Copy.Members(view, d);
            return new EventDomain (d);
        }

        public static EventView Create(EventDomain obj)
        {
            var v = new EventView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
