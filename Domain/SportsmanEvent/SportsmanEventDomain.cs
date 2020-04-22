using North.Data.SportsmanEvent;
using North.Domain.Common;

namespace North.Domain.SportsmanEvent
{
    public sealed class SportsmanEventDomain : Entity<SportsmanEventData>
    {
        public SportsmanEventDomain() : this(null) { }
        public SportsmanEventDomain(SportsmanEventData data) : base(data) { }
    }
}
