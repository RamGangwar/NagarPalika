using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TariffPlans
{
    public class GetTariffPlanByFilterHandler : IRequestHandler<GetTariffPlanByFilterQuery, PagingModel<TariffPlanVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTariffPlanByFilterHandler> _logger;

        public GetTariffPlanByFilterHandler(IUnitofWork unitofWork, ILogger<GetTariffPlanByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TariffPlanVM>> Handle(GetTariffPlanByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TariffPlan.GetByPaging(request);
            return new PagingModel<TariffPlanVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

