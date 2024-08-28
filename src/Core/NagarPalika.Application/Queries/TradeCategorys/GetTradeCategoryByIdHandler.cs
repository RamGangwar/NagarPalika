using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TradeCategorys
{
    public class GetTradeCategoryByIdHandler : IRequestHandler<GetTradeCategoryByIdQuery, ResponseModel<TradeCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTradeCategoryByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTradeCategoryByIdHandler(IUnitofWork unitofWork, ILogger<GetTradeCategoryByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TradeCategoryVM>> Handle(GetTradeCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.TradeCategory.GetById(request.TradeCategoryId)).Adapt<TradeCategoryVM>();
            return new ResponseModel<TradeCategoryVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
            throw new NotImplementedException();
        }
    }
}

