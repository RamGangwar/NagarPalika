using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.Zone
{
    public class CreateZonesHandler : IRequestHandler<CreateZonesCommand, ResponseModel<ZonesVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateZonesHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateZonesHandler(IUnitofWork unitofWork, ILogger<CreateZonesHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<ZonesVM>> Handle(CreateZonesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<ZonesVM>();
            var dept = await _unitofWork.Zones.GetByClause(new { ZoneName = request.ZoneName });
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<Zones>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Zones.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Zones.GetById(result);
                    response.Data = res.Adapt<ZonesVM>();
                    response.Succeeded=true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded=false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded=false;
                response.Message = "Zone Already Exists.";
                return response;
            }
        }
    }
}
