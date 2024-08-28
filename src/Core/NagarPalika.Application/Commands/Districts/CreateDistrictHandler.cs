using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Districts
{
    public class CreateDistrictHandler : IRequestHandler<CreateDistrictCommand, ResponseModel<DistrictVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDistrictHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateDistrictHandler(IUnitofWork unitofWork, ILogger<CreateDistrictHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DistrictVM>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DistrictVM>();
            var query = new { DistrictName = request.DistrictName };
            var dept = await _unitofWork.Districts.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<District>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Districts.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Districts.GetById(result);
                    response.Data = res.Adapt<DistrictVM>();
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
                response.Message = "District Already Exists.";
                return response;
            }
        }
    }
}

