using North.Aids;
using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;

namespace North.Facade.SportsmanEvent
{
    public static class SportsmanEventViewFactory
    {
        public static SportsmanEventDomain Create(SportsmanEventView view)
        {
            var d = new SportsmanEventData();
            Copy.Members(view, d);
            return new SportsmanEventDomain(d);
        }


        public static SportsmanEventView Create(SportsmanEventDomain obj)
        {
            var v = new SportsmanEventView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
