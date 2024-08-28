using Dapper;
using NagarPalika.Application.Queries.Role;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        public RolesRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
                
        }
        public async Task<IEnumerable<RolesVM>> GetByPaging(GetRolesByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , R.*,E.EmployeeName from Roles R left join Employee E on R.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RolesVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
