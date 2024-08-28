using Dapper;
using NagarPalika.Application.Queries.Zone;
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
    public class ZonesRepository : GenericRepository<Zones>, IZonesRepository
    {
        public ZonesRepository(IBaseUnitOfWork unitofWork) : base(unitofWork)
        {
        }
        public async Task<IEnumerable<ZonesVM>> GetByPaging(GetZonesByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Select COUNT(1) OVER () as TotalRecord , Z.*,D.DistrictName,E.EmployeeName from Zones Z
                        left join District D on Z.DistrictId=D.DistrictId 
                        left join Employee E on Z.CreatedBy=E.EmployeeId 
                        ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<ZonesVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
