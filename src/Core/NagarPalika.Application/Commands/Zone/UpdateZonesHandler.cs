using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Zone
{
    public class UpdateZonesHandler : IRequestHandler<UpdateZonesCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateZonesHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateZonesHandler(IUnitofWork unitofWork, ILogger<UpdateZonesHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateZonesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { ZoneName = request.ZoneName , ZoneId_neq = request.ZoneId };
            var deptDuplicate = await _unitofWork.Zones.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Zone Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.Zones.GetById(request.ZoneId);
            if (dept != null && dept.ZoneId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                
                dept.ZoneName = request.ZoneName;
                dept.DistrictId = request.DistrictId;
                dept.ZoneCode = request.ZoneCode;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.Zones.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
