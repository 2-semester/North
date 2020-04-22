using North.Data.Sportsman;
using North.Domain.Common;

namespace North.Domain.Sportsman
{
    public sealed class SportsmanDomain : Entity<SportsmanData>
    {
        public SportsmanDomain() : this(null) { }
        public SportsmanDomain(SportsmanData data) : base(data) { }
    }
}
