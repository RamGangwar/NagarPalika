using Dapper;
 using NagarPalika.Application.Queries.MutationTypes;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class MutationTypeRepository : GenericRepository<MutationType>, IMutationTypeRepository
    {
        public MutationTypeRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<MutationTypeVM>> GetByPaging(GetMutationTypeByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , MT.*,E.EmployeeName from MutationType MT left join Employee E on MT.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<MutationTypeVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
