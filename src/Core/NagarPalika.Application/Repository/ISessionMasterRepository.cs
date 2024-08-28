using NagarPalika.Application.Queries.SessionMasters;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ISessionMasterRepository : IGenericRepository<SessionMaster>
    {
        Task<IEnumerable<SessionMasterVM>> GetByPaging(GetSessionMasterByFilterQuery filterQuery);
    }
}

