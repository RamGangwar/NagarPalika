using NagarPalika.Application.Queries.Employees;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NagarPalika.Application.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByEmail(string Email);
        Task<Employee> GetDuplicateByUserName(int UserId, string UserName);
        Task<Employee> GetByUserName(string UserName);
        Task<IEnumerable<EmployeeVM>> GetByPaging(GetAllEmployeeQuery query);
    }
}
