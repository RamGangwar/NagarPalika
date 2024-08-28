using NagarPalika.Application.Queries.DisabilitySlabs;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IDisabilitySlabRepository : IGenericRepository<DisabilitySlab>
    {
        Task<IEnumerable<DisabilitySlabVM>> GetByPaging(GetDisabilitySlabByFilterQuery filterQuery);
    }
}
