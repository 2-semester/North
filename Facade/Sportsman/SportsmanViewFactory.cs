using North.Aids;
using North.Data.Sportsman;
using North.Domain.Sportsman;

namespace North.Facade.Sportsman
{
    public static class SportsmanViewFactory
    {
        public static SportsmanDomain Create(SportsmanView view)
        {
            var d = new SportsmanData();
            Copy.Members(view, d);
            return new SportsmanDomain(d);
        }

        public static SportsmanView Create(SportsmanDomain obj)
        {
            var v = new SportsmanView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
