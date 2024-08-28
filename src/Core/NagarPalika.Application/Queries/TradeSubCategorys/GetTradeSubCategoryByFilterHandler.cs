using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeSubCategorys
{
    public class GetTradeSubCategoryByFilterHandler : IRequestHandler<GetTradeSubCategoryByFilterQuery, PagingModel<TradeSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeSubCategoryByFilterHandler> _logger;

        public GetTradeSubCategoryByFilterHandler(IUnitofWork unitofWork, ILogger<GetTradeSubCategoryByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TradeSubCategoryVM>> Handle(GetTradeSubCategoryByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TradeSubCategory.GetByPaging(request);
            return new PagingModel<TradeSubCategoryVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

