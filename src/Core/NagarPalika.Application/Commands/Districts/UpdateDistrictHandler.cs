using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Districts
{
    public class UpdateDistrictHandler : IRequestHandler<UpdateDistrictCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDistrictHandler> _logger; 
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateDistrictHandler(IUnitofWork unitofWork, ILogger<UpdateDistrictHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { DistrictName = request.DistrictName, DistrictId_neq = request.DistrictId };
            var deptDuplicate = await _unitofWork.Districts.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "District Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.Districts.GetById(request.DistrictId);
            if (dept != null && dept.DistrictId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.DistrictName = request.DistrictName;
                dept.DistrictCode = request.DistrictCode;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.Districts.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

