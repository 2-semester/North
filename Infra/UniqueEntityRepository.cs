using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using North.Data.Common;
using North.Domain.Common;

namespace North.Infra
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TData :UniqueEntityData, new()
        where TDomain : Entity<TData>, new()
    {

        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        protected override async Task<TData> getData(string id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

        protected override string getId(TDomain entity)
        {
            return entity?.Data?.Id;
        }
    }
}
