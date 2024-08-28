using NagarPalika.Application.Queries.AssetSubCategorys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IAssetSubCategoryRepository : IGenericRepository<AssetSubCategory>
    {
        Task<IEnumerable<AssetSubCategoryVM>> GetByPaging(GetAssetSubCategoryByFilterQuery filterQuery);
    }
}

