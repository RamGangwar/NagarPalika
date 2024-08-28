using NagarPalika.Application.Queries.Departments;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<DepartmentVM>> GetByPaging(GetDepartmentByFilterQuery filterQuery);
    }
}
