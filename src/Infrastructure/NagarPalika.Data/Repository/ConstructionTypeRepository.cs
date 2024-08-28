using Dapper;
using NagarPalika.Application.Queries.ConstructionTypes;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class ConstructionTypeRepository : GenericRepository<ConstructionType>, IConstructionTypeRepository
    {
        public ConstructionTypeRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<ConstructionTypeVM>> GetByPaging(GetConstructionTypeByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , CT.*,E.EmployeeName from ConstructionType CT left join Employee E on CT.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<ConstructionTypeVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
