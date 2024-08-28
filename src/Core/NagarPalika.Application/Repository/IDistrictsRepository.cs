using NagarPalika.Application.Queries.Designations;
using NagarPalika.Application.Queries.Districts;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IDistrictsRepository : IGenericRepository<District>
    {
        Task<IEnumerable<DistrictVM>> GetByPaging(GetDistrictByFilterQuery filterQuery);
    }
}
