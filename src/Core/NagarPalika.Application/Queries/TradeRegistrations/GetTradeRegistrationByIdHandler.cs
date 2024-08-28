using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TradeRegistrations
{
    public class GetTradeRegistrationByIdHandler : IRequestHandler<GetTradeRegistrationByIdQuery, ResponseModel<TradeRegistrationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeRegistrationByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTradeRegistrationByIdHandler(IUnitofWork unitofWork, ILogger<GetTradeRegistrationByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TradeRegistrationVM>> Handle(GetTradeRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.TradeRegistration.GetById(request.TradeRegistrationId)).Adapt<TradeRegistrationVM>();
            return new ResponseModel<TradeRegistrationVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

