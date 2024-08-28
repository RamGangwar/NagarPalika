using Dapper;
using NagarPalika.Application.Queries.Designations;
using NagarPalika.Application.Queries.Districts;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Data.Repository
{
    public class DistrictsRepository : GenericRepository<District>, IDistrictsRepository
    {
        public DistrictsRepository(IBaseUnitOfWork unitofWork) : base(unitofWork)
        {
        }
        public async Task<IEnumerable<DistrictVM>> GetByPaging(GetDistrictByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , D.*, E.EmployeeName from District D left join Employee E On D.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<DistrictVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
