using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeCategorys
{
    public class GetTradeCategoryByFilterHandler : IRequestHandler<GetTradeCategoryByFilterQuery, PagingModel<TradeCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeCategoryByFilterHandler> _logger;

        public GetTradeCategoryByFilterHandler(IUnitofWork unitofWork, ILogger<GetTradeCategoryByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TradeCategoryVM>> Handle(GetTradeCategoryByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TradeCategory.GetByPaging(request);
            return new PagingModel<TradeCategoryVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

