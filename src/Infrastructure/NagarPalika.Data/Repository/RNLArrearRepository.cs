using Dapper;
using NagarPalika.Application.Queries.RNLArrears;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RNLArrearRepository : GenericRepository<RNLArrear>, IRNLArrearRepository
    {
        public RNLArrearRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<RNLArrearVM>> GetByPaging(GetRNLArrearByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, RA.*,E.EmployeeName from RNLArrear RA left join Employee E On RA.CreatedBY=E.EmployeeId   ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RNLArrearVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

