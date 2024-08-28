using NagarPalika.Application.Queries.PropertyTypes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IPropertyTypeRepository : IGenericRepository<PropertyType>
    {
        Task<IEnumerable<PropertyTypeVM>> GetByPaging(GetPropertyTypeByFilterQuery filterQuery);
    }
}
