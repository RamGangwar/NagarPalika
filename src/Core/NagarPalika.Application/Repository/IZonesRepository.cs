using NagarPalika.Application.Queries.Zone;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IZonesRepository:IGenericRepository<Zones>
    {
        Task<IEnumerable<ZonesVM>> GetByPaging(GetZonesByFilterQuery filterQuery);
    }
}
