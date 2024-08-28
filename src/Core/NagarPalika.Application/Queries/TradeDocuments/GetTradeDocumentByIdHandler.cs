using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TradeDocuments
{
    public class GetTradeDocumentByIdHandler : IRequestHandler<GetTradeDocumentByIdQuery, ResponseModel<TradeDocumentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeDocumentByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTradeDocumentByIdHandler(IUnitofWork unitofWork, ILogger<GetTradeDocumentByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TradeDocumentVM>> Handle(GetTradeDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.TradeDocuments.GetById(request.TradeDocumentId)).Adapt<TradeDocumentVM>();
            return new ResponseModel<TradeDocumentVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

