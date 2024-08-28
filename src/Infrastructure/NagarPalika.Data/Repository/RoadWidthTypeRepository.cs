using Dapper;
 using NagarPalika.Application.Queries.RoadWidthTypes;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RoadWidthTypeRepository : GenericRepository<RoadWidthType>, IRoadWidthTypeRepository
    {
        public RoadWidthTypeRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<RoadWidthTypeVM>> GetByPaging(GetRoadWidthTypeByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , RW.*,E.EmployeeName from RoadWidthType RW left join Employee E on RW.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RoadWidthTypeVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
