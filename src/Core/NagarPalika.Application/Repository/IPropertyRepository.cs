using NagarPalika.Application.Queries.Propertys;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IPropertyRepository : IGenericRepository<Property>
    {
        Task<IEnumerable<PropertyVM>> GetByPaging(GetPropertyByFilterQuery filterQuery);
    }
}

