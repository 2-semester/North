using North.Data.SportsmanEvent;
using North.Domain.Common;

namespace North.Domain.SportsmanEvent
{
    public sealed class SportsmanEvent : Entity<SportsmanEventData>
    {
        public SportsmanEvent() : this(null) { }
        public SportsmanEvent(SportsmanEventData data) : base(data) { }
    }
}
