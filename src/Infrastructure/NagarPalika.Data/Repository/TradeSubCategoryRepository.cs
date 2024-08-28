using Dapper;
using NagarPalika.Application.Queries.TradeSubCategorys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TradeSubCategoryRepository : GenericRepository<TradeSubCategory>, ITradeSubCategoryRepository
    {
        public TradeSubCategoryRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TradeSubCategoryVM>> GetByPaging(GetTradeSubCategoryByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, TS.*, TC.TradeCategoryName,E.EmployeeName from TradeSubCategory TS left join TradeCategory TC on TS.TradeCategoryId=TC.TradeCategoryId left join Employee E on TS.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
           DynamicParameters parameters = new DynamicParameters();
           parameters.Add("SkipRow", filterQuery.SkipRow);
           parameters.Add("PageSize", filterQuery.PageSize);
           return (await _DbConnection.QueryAsync<TradeSubCategoryVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

