using North.Data.Location;
using North.Domain.Common;

namespace North.Domain.Location
{
    public class LocationDomain : Entity<LocationData>
    {
        public LocationDomain() : this(null) { }
        public LocationDomain(LocationData data) : base(data) { }
    }
}
