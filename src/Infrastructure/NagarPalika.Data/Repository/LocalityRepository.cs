using Dapper;
using NagarPalika.Application.Queries.Localitys;
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
    public class LocalityRepository : GenericRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(IBaseUnitOfWork unitofWork) : base(unitofWork)
        {
        }

        public async Task<IEnumerable<LocalityVM>> GetByPaging(GetLocalityByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , L.*,W.WardName,E.EmployeeName from Locality L left join Wards W on L.WardId=W.WardId Left join Employee E on L.CreatedBy=E.EmployeeId  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<LocalityVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
