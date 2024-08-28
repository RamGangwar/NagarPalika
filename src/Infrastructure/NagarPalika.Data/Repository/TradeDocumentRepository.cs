using Dapper;
using NagarPalika.Application.Queries.TradeDocuments;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TradeDocumentRepository : GenericRepository<TradeDocument>, ITradeDocumentRepository
    {
        public TradeDocumentRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TradeDocumentVM>> GetByPaging(GetTradeDocumentByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, TD.*,E.EmployeeName from TradeDocument TD left join Employee E on TD.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
           DynamicParameters parameters = new DynamicParameters();
           parameters.Add("SkipRow", filterQuery.SkipRow);
           parameters.Add("PageSize", filterQuery.PageSize);
           return (await _DbConnection.QueryAsync<TradeDocumentVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

