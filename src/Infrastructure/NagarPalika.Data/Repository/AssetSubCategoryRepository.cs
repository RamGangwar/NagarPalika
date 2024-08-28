using Dapper;
using NagarPalika.Application.Queries.AssetSubCategorys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class AssetSubCategoryRepository : GenericRepository<AssetSubCategory>, IAssetSubCategoryRepository
    {
        public AssetSubCategoryRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<AssetSubCategoryVM>> GetByPaging(GetAssetSubCategoryByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, AC.*,E.EmployeeName,A.AssetCategoryName from AssetSubCategory AC left join AssetCategory A on AC.AssetCategoryId=A.AssetCategoryId left join Employee E On AC.CreatedBY=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<AssetSubCategoryVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

