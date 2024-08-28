using Dapper;
using NagarPalika.Application.Queries.TariffPlans;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TariffPlanRepository : GenericRepository<TariffPlan>, ITariffPlanRepository
    {
        public TariffPlanRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TariffPlanVM>> GetByPaging(GetTariffPlanByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , T.*,E.EmployeeName from TariffPlan T left join Employee E on T.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<TariffPlanVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
