using NagarPalika.Application.Queries.TradeCategorys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITradeCategoryRepository : IGenericRepository<TradeCategory>
    {
        Task<IEnumerable<TradeCategoryVM>> GetByPaging(GetTradeCategoryByFilterQuery filterQuery);
    }
}

