using Dapper;
using NagarPalika.Application.Queries.Ward;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class WardsRepository : GenericRepository<Wards>, IWardsRepository
    {
        public WardsRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<IEnumerable<WardsVM>> GetByPaging(GetWardsByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Select COUNT(1) OVER () as TotalRecord, W.*,E.EmployeeName,Z.ZoneName from Wards W 
                        left join Zones Z on W.ZoneId=Z.ZoneId
                        left join Employee E on W.CreatedBy=E.EmployeeId
                        ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<WardsVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
