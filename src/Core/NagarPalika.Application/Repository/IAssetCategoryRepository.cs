using NagarPalika.Application.Queries.AssetCategorys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IAssetCategoryRepository : IGenericRepository<AssetCategory>
    {
        Task<IEnumerable<AssetCategoryVM>> GetByPaging(GetAssetCategoryByFilterQuery filterQuery);
    }
}

