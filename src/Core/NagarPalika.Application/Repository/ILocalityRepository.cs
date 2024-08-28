using NagarPalika.Application.Queries.Localitys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ILocalityRepository : IGenericRepository<Locality>
    {
        Task<IEnumerable<LocalityVM>> GetByPaging(GetLocalityByFilterQuery filterQuery);
    }
}
