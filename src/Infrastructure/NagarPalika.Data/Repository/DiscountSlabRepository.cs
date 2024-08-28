using Dapper;
using NagarPalika.Application.Queries.DiscountSlabs;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class DiscountSlabRepository : GenericRepository<DiscountSlab>, IDiscountSlabRepository
    {
        public DiscountSlabRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<DiscountSlabVM>> GetByPaging(GetDiscountSlabByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , DS.*,E.EmployeeName from DiscountSlab DS left join Employee E on DS.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<DiscountSlabVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
