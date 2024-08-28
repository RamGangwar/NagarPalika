using NagarPalika.Application.Queries.MutationTypes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IMutationTypeRepository : IGenericRepository<MutationType>
    {
        Task<IEnumerable<MutationTypeVM>> GetByPaging(GetMutationTypeByFilterQuery filterQuery);
    }
}
