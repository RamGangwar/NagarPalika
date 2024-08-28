using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.SessionMasters
{
    public class UpdateSessionMasterHandler : IRequestHandler<UpdateSessionMasterCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateSessionMasterHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateSessionMasterHandler(IUnitofWork unitofWork, ILogger<UpdateSessionMasterHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateSessionMasterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {SessionMasterName = request.SessionMasterName, SessionMasterId_neq = request.SessionMasterId };
//            var deptDuplicate = await _unitofWork.SessionMasters.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "SessionMaster Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.SessionMasters.GetById(request.SessionMasterId);
//            if (dept != null && dept.SessionMasterId > 0)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                dept.SessionMasterName = request.SessionMasterName;
//                dept.ModifyBy = Convert.ToInt32(empId);
//                dept.ModifyOn = DateTime.Now;
//                var result = await _unitofWork.SessionMasters.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

