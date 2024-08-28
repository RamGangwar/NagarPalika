using Dapper;
 using NagarPalika.Application.Queries.TenantSlabs;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TenantSlabRepository : GenericRepository<TenantSlab>, ITenantSlabRepository
    {
        public TenantSlabRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TenantSlabVM>> GetByPaging(GetTenantSlabByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , TS.*, E.EmployeeName from TenantSlab TS left join Employee E on TS.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<TenantSlabVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
