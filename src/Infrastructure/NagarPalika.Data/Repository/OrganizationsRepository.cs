using Dapper;
using NagarPalika.Application.Queries.Organization;
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
    public class OrganizationsRepository : GenericRepository<Organizations>, IOrganizationsRepository
    {
        public OrganizationsRepository(IBaseUnitOfWork unitofWork) : base(unitofWork)
        {
        }

        public async Task<IEnumerable<OrganizationVM>> GetByPaging(GetOrganizationByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , O.*,D.DistrictName from Organizations O left join District D on O.DistrictId=D.DistrictId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<OrganizationVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
