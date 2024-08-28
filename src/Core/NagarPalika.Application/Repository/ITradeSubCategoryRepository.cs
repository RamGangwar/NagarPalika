using NagarPalika.Application.Queries.TradeSubCategorys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITradeSubCategoryRepository : IGenericRepository<TradeSubCategory>
    {
        Task<IEnumerable<TradeSubCategoryVM>> GetByPaging(GetTradeSubCategoryByFilterQuery filterQuery);
    }
}

