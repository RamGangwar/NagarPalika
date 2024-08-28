using Dapper;
using NagarPalika.Application.Queries.AssetCategorys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class AssetCategoryRepository : GenericRepository<AssetCategory>, IAssetCategoryRepository
    {
        public AssetCategoryRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<AssetCategoryVM>> GetByPaging(GetAssetCategoryByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, AC.*,E.EmployeeName from AssetCategory AC left join Employee E On AC.CreatedBY=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<AssetCategoryVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

