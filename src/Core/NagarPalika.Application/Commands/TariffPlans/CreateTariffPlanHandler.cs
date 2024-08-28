using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.TariffPlans
{
    public class CreateTariffPlanHandler : IRequestHandler<CreateTariffPlanCommand, ResponseModel<TariffPlanVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateTariffPlanHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTariffPlanHandler(IUnitofWork unitofWork, ILogger<CreateTariffPlanHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TariffPlanVM>> Handle(CreateTariffPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<TariffPlanVM>();
            var query = new { PropertyType = request.PropertyType };
            var dept = await _unitofWork.TariffPlan.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<TariffPlan>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.TariffPlan.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.TariffPlan.GetById(result);
                    response.Data = res.Adapt<TariffPlanVM>();
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
                response.Message = "Tariff Plan Already Exists.";
                return response;
            }
        }
}
}
