using NagarPalika.Application.Queries.AccessPermissions;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IAccessPermissionRepository : IGenericRepository<AccessPermission>
    {
        Task<IEnumerable<AccessPermissionVM>> GetByPaging(GetAccessPermissionByFilterQuery filterQuery);
        Task<ResponseModel> DeleteByRole(int RoleId);
    }
}

