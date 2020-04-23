using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Location;
using North.Domain.Location;
using North.Infra;
using North.Infra.Location;

namespace North.Tests.Infra.Location
{
    [TestClass]
    public class LocationsRepositoryTests : RepositoryTests<LocationsRepository, LocationDomain, LocationData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<LocationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new LocationDbContext(options);
            dbSet = ((LocationDbContext)db).Locations;
            obj = new LocationsRepository((LocationDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<LocationDomain, LocationData>);
        }

        protected override string getId(LocationData d) => d.Id;

        protected override LocationDomain getObject(LocationData d) => new LocationDomain(d);

        protected override void setId(LocationData d, string id) => d.Id = id;
    }
}
