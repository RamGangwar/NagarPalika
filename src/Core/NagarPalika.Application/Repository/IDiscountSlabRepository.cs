using NagarPalika.Application.Queries.DiscountSlabs;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IDiscountSlabRepository : IGenericRepository<DiscountSlab>
    {
        Task<IEnumerable<DiscountSlabVM>> GetByPaging(GetDiscountSlabByFilterQuery filterQuery);
    }
}
