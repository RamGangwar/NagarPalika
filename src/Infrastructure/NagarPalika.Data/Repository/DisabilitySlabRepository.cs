using Dapper;
 using NagarPalika.Application.Queries.DisabilitySlabs;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class DisabilitySlabRepository : GenericRepository<DisabilitySlab>, IDisabilitySlabRepository
    {
        public DisabilitySlabRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<DisabilitySlabVM>> GetByPaging(GetDisabilitySlabByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , DS.*, E.EmployeeName from DisabilitySlab DS left join Employee E on DS.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<DisabilitySlabVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
