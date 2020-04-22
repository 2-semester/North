using North.Data.Location;
using North.Domain.Common;

namespace North.Domain.Location
{
    public class Location : Entity<LocationData>
    {
        public Location() : this(null) { }
        public Location(LocationData data) : base(data) { }
    }
}
