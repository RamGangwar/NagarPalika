using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Ward
{
    public class UpdateWardsHandler : IRequestHandler<UpdateWardsCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateWardsHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateWardsHandler(IUnitofWork unitofWork, ILogger<UpdateWardsHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateWardsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { WardName = request.WardName , WardId_neq = request.WardId };
            var deptDuplicate = await _unitofWork.Wards.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Ward Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.Wards.GetById(request.WardId);
            if (dept != null && dept.WardId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.WardName = request.WardName;
                dept.ZoneId = request.ZoneId;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.Wards.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
