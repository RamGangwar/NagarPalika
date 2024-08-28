using Dapper;
using NagarPalika.Application.Queries.AccessPermissions;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class AccessPermissionRepository : GenericRepository<AccessPermission>, IAccessPermissionRepository
    {
        public AccessPermissionRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ResponseModel> DeleteByRole(int RoleId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from AccessPermission where RoleId=@RoleId");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("RoleId", RoleId);
            var res = await _DbConnection.ExecuteAsync(sb.ToString(), parameters, _DbTransaction);
            return (new ResponseModel { Succeeded = res > 0 ? true : false, Message = res > 0 ? "Deleted" : "Failed" });
        }

        public async Task<IEnumerable<AccessPermissionVM>> GetByPaging(GetAccessPermissionByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, * from AccessPermission AP where 1=1 ");
            DynamicParameters parameters = new DynamicParameters();
            sb.Append(" and AP.RoleId=@RoleId");
            parameters.Add("RoleId", filterQuery.RoleId);

            return (await _DbConnection.QueryAsync<AccessPermissionVM>(sb.ToString(), parameters, _DbTransaction));
        }

    }
}

