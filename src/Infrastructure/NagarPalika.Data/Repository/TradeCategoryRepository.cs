using Dapper;
using NagarPalika.Application.Queries.TradeCategorys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TradeCategoryRepository : GenericRepository<TradeCategory>, ITradeCategoryRepository
    {
        public TradeCategoryRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TradeCategoryVM>> GetByPaging(GetTradeCategoryByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, TC.*,E.EmployeeName from TradeCategory TC left join Employee E on TC.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
           DynamicParameters parameters = new DynamicParameters();
           parameters.Add("SkipRow", filterQuery.SkipRow);
           parameters.Add("PageSize", filterQuery.PageSize);
           return (await _DbConnection.QueryAsync<TradeCategoryVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

