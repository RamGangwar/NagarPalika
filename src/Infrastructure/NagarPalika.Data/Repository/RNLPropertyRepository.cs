using Dapper;
using NagarPalika.Application.Queries.RNLPropertys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RNLPropertyRepository : GenericRepository<RNLProperty>, IRNLPropertyRepository
    {
        public RNLPropertyRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<RNLPropertyVM>> GetByPaging(GetRNLPropertyByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, RP.*, E.EmployeeName from RNLProperty RP left join Employee E On RP.CreatedBY=E.EmployeeId   ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RNLPropertyVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

