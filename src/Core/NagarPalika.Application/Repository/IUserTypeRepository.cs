using NagarPalika.Application.Queries.UserTypes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IUserTypeRepository : IGenericRepository<UserType>
    {
        Task<IEnumerable<UserTypeVM>> GetByPaging(GetUserTypeByFilterQuery filterQuery);
    }
}

