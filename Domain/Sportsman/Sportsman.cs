using North.Data.Sportsman;
using North.Domain.Common;

namespace North.Domain.Sportsman
{
    public sealed class Sportsman : Entity<SportsmanData>
    {
        public Sportsman() : this(null) { }
        public Sportsman(SportsmanData data) : base(data) { }
    }
}
