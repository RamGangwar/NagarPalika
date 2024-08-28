using NagarPalika.Application.Queries.RNLArrears;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRNLArrearRepository : IGenericRepository<RNLArrear>
    {
        Task<IEnumerable<RNLArrearVM>> GetByPaging(GetRNLArrearByFilterQuery filterQuery);
    }
}

