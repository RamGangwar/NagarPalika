using Dapper;
using NagarPalika.Application.Queries.RNLAllotments;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RNLAllotmentRepository : GenericRepository<RNLAllotment>, IRNLAllotmentRepository
    {
        public RNLAllotmentRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<RNLAllotmentVM>> GetByPaging(GetRNLAllotmentByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, RA.*,E.EmployeeName from RNLAllotment RA left join Employee E On RA.CreatedBY=E.EmployeeId   ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RNLAllotmentVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

