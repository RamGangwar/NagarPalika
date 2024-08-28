using NagarPalika.Application.Queries.Role;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRolesRepository : IGenericRepository<Roles>
    {
        Task<IEnumerable<RolesVM>> GetByPaging(GetRolesByFilterQuery filterQuery);
    }
}
