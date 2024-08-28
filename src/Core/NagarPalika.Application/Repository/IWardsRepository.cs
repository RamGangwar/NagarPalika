using NagarPalika.Application.Queries.Ward;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IWardsRepository : IGenericRepository<Wards>
    {
        Task<IEnumerable<WardsVM>> GetByPaging(GetWardsByFilterQuery filterQuery);
    }
}
