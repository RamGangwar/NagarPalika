using Dapper;
using NagarPalika.Application.Queries.Employees;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Employee> GetByEmail(string Email)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from Employee where EmailId=@Email");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", Email);
            return (await _DbConnection.QueryAsync<Employee>(sb.ToString(), parameters, _DbTransaction)).FirstOrDefault();
        }

        public async Task<IEnumerable<EmployeeVM>> GetByPaging(GetAllEmployeeQuery query)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , E.*, Dt.DepartmentName,Dg.DesignationName from Employee E left join  Department Dt on E.DepartmentId=Dt.DepartmentId left join Designation Dg on E.DesignationId=Dg.DesignationId ORDER BY " + query.SortBy + " " + query.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", query.SkipRow);
            parameters.Add("PageSize", query.PageSize);
            return (await _DbConnection.QueryAsync<EmployeeVM>(sb.ToString(), parameters, _DbTransaction));
        }

        public async Task<Employee> GetByUserName(string UserName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from Employee where UserName=@UserName");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserName", UserName);
            return (await _DbConnection.QueryAsync<Employee>(sb.ToString(), parameters, _DbTransaction)).FirstOrDefault();
        }


        public async Task<Employee> GetDuplicateByUserName(int EmployeeId, string UserName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from Employee where EmployeeId<>@EmployeeId and UserName=@UserName");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmployeeId", EmployeeId);
            parameters.Add("UserName", UserName);

            return (await _DbConnection.QueryAsync<Employee>(sb.ToString(), parameters, _DbTransaction)).FirstOrDefault();
        }

    }
}
