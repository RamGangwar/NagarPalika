using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TradeSubCategorys
{
    public class GetTradeSubCategoryByIdHandler : IRequestHandler<GetTradeSubCategoryByIdQuery, ResponseModel<TradeSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeSubCategoryByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTradeSubCategoryByIdHandler(IUnitofWork unitofWork, ILogger<GetTradeSubCategoryByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TradeSubCategoryVM>> Handle(GetTradeSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.TradeSubCategory.GetById(request.TradeSubCategoryId)).Adapt<TradeSubCategoryVM>();
            return new ResponseModel<TradeSubCategoryVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

