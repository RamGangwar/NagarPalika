using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.AccessPermissions
{
    public class UpdateAccessPermissionHandler : IRequestHandler<UpdateAccessPermissionCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateAccessPermissionHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateAccessPermissionHandler(IUnitofWork unitofWork, ILogger<UpdateAccessPermissionHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateAccessPermissionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {AccessPermissionName = request.AccessPermissionName, AccessPermissionId_neq = request.AccessPermissionId };
//            var deptDuplicate = await _unitofWork.AccessPermissions.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "AccessPermission Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.AccessPermissions.GetById(request.AccessPermissionId);
//            if (dept != null && dept.AccessPermissionId > 0)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                dept.AccessPermissionName = request.AccessPermissionName;
//                dept.ModifyBy = Convert.ToInt32(empId);
//                dept.ModifyOn = DateTime.Now;
//                var result = await _unitofWork.AccessPermissions.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

