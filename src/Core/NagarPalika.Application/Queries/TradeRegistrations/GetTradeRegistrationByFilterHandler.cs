using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeRegistrations
{
    public class GetTradeRegistrationByFilterHandler : IRequestHandler<GetTradeRegistrationByFilterQuery, PagingModel<TradeRegistrationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeRegistrationByFilterHandler> _logger;

        public GetTradeRegistrationByFilterHandler(IUnitofWork unitofWork, ILogger<GetTradeRegistrationByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TradeRegistrationVM>> Handle(GetTradeRegistrationByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TradeRegistration.GetByPaging(request);
            return new PagingModel<TradeRegistrationVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

