using NagarPalika.Application.Queries.TenantSlabs;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITenantSlabRepository : IGenericRepository<TenantSlab>
    {
        Task<IEnumerable<TenantSlabVM>> GetByPaging(GetTenantSlabByFilterQuery filterQuery);
    }
}
