using Dapper;
using NagarPalika.Application.Queries.SessionMasters;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class SessionMasterRepository : GenericRepository<SessionMaster>, ISessionMasterRepository
    {
        public SessionMasterRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<SessionMasterVM>> GetByPaging(GetSessionMasterByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, *from SessionMaster  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
           DynamicParameters parameters = new DynamicParameters();
           parameters.Add("SkipRow", filterQuery.SkipRow);
           parameters.Add("PageSize", filterQuery.PageSize);
           return (await _DbConnection.QueryAsync<SessionMasterVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

