using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Propertys
{
    public class UpdatePropertyHandler : IRequestHandler<UpdatePropertyCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdatePropertyHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdatePropertyHandler(IUnitofWork unitofWork, ILogger<UpdatePropertyHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {PropertyName = request.PropertyName, PropertyId_neq = request.PropertyId };
//            var deptDuplicate = await _unitofWork.Propertys.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "Property Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.Propertys.GetById(request.PropertyId);
//            if (dept != null && dept.PropertyId > 0)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                dept.PropertyName = request.PropertyName;
//                dept.ModifyBy = Convert.ToInt32(empId);
//                dept.ModifyOn = DateTime.Now;
//                var result = await _unitofWork.Propertys.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

