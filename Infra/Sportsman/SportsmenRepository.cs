using North.Data.Sportsman;
using North.Domain.Sportsman;

namespace North.Infra.Sportsman
{
    public sealed class SportsmenRepository : UniqueEntityRepository<SportsmanDomain, SportsmanData>, ISportsmenRepository
    {
        public SportsmenRepository(SportsmanDbContext c) : base(c, c.Sportsmen) { }

        protected internal override SportsmanDomain toDomainObject(SportsmanData d) => new SportsmanDomain(d);
    }
}
