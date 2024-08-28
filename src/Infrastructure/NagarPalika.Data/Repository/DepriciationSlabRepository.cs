using Dapper;
 using NagarPalika.Application.Queries.DepriciationSlabs;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class DepriciationSlabRepository : GenericRepository<DepriciationSlab>, IDepriciationSlabRepository
    {
        public DepriciationSlabRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<DepriciationSlabVM>> GetByPaging(GetDepriciationSlabByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , DS.*,E.EmployeeName from DepriciationSlab DS left join Employee E on DS.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<DepriciationSlabVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
