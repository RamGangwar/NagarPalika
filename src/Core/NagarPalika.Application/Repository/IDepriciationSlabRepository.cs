using NagarPalika.Application.Queries.DepriciationSlabs;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IDepriciationSlabRepository : IGenericRepository<DepriciationSlab>
    {
        Task<IEnumerable<DepriciationSlabVM>> GetByPaging(GetDepriciationSlabByFilterQuery filterQuery);
    }
}
