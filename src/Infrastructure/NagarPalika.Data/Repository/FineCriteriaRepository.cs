using Dapper;
 using NagarPalika.Application.Queries.FineCriterias;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class FineCriteriaRepository : GenericRepository<FineCriteria>, IFineCriteriaRepository
    {
        public FineCriteriaRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<FineCriteriaVM>> GetByPaging(GetFineCriteriaByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , FC.*,E.EmployeeName from FineCriteria FC left join Employee E on FC.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<FineCriteriaVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
