using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.DiscountSlabs
{
    public class GetDiscountSlabByIdHandler : IRequestHandler<GetDiscountSlabByIdQuery, ResponseModel<DiscountSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDiscountSlabByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetDiscountSlabByIdHandler(IUnitofWork unitofWork, ILogger<GetDiscountSlabByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<DiscountSlabVM>> Handle(GetDiscountSlabByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.DiscountSlab.GetById(request.DiscountSlabId)).Adapt<DiscountSlabVM>();
            return new ResponseModel<DiscountSlabVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

