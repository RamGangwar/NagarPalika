using NagarPalika.Application.Queries.RoadWidthTypes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRoadWidthTypeRepository : IGenericRepository<RoadWidthType>
    {
        Task<IEnumerable<RoadWidthTypeVM>> GetByPaging(GetRoadWidthTypeByFilterQuery filterQuery);
    }
}
