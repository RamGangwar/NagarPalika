using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.UserTypes
{
    public class UpdateUserTypeHandler : IRequestHandler<UpdateUserTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateUserTypeHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateUserTypeHandler(IUnitofWork unitofWork, ILogger<UpdateUserTypeHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {UserTypeName = request.UserTypeName, UserTypeId_neq = request.UserTypeId };
//            var deptDuplicate = await _unitofWork.UserTypes.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "UserType Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.UserTypes.GetById(request.UserTypeId);
//            if (dept != null && dept.UserTypeId > 0)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                dept.UserTypeName = request.UserTypeName;
//                dept.ModifyBy = Convert.ToInt32(empId);
//                dept.ModifyOn = DateTime.Now;
//                var result = await _unitofWork.UserTypes.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

