using NagarPalika.Application.Queries.ConstructionTypes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IConstructionTypeRepository : IGenericRepository<ConstructionType>
    {
        Task<IEnumerable<ConstructionTypeVM>> GetByPaging(GetConstructionTypeByFilterQuery filterQuery);
    }
}
