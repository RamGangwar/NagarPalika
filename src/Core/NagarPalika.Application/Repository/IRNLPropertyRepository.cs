using NagarPalika.Application.Queries.RNLPropertys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRNLPropertyRepository : IGenericRepository<RNLProperty>
    {
        Task<IEnumerable<RNLPropertyVM>> GetByPaging(GetRNLPropertyByFilterQuery filterQuery);
    }
}

