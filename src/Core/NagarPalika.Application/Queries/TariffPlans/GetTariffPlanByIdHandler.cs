using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TariffPlans
{
    public class GetTariffPlanByIdHandler : IRequestHandler<GetTariffPlanByIdQuery, ResponseModel<TariffPlanVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTariffPlanByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTariffPlanByIdHandler(IUnitofWork unitofWork, ILogger<GetTariffPlanByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TariffPlanVM>> Handle(GetTariffPlanByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.TariffPlan.GetById(request.TariffPlanId)).Adapt<TariffPlanVM>();
            return new ResponseModel<TariffPlanVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

