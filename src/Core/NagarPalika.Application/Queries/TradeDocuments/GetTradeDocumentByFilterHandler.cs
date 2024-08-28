using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeDocuments
{
    public class GetTradeDocumentByFilterHandler : IRequestHandler<GetTradeDocumentByFilterQuery, PagingModel<TradeDocumentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeDocumentByFilterHandler> _logger;

        public GetTradeDocumentByFilterHandler(IUnitofWork unitofWork, ILogger<GetTradeDocumentByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TradeDocumentVM>> Handle(GetTradeDocumentByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TradeDocuments.GetByPaging(request);
            return new PagingModel<TradeDocumentVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

