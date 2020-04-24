using North.Data.Location;
using North.Domain.Location;

namespace North.Infra.Location
{
    public sealed class LocationsRepository : UniqueEntityRepository<LocationDomain, LocationData>, ILocationsRepository
    {
        public LocationsRepository(NorthDbContext c) : base(c, c.Locations) { }

        protected internal override LocationDomain toDomainObject(LocationData d) => new LocationDomain(d);
    }
}
