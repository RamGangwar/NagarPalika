using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.DisabilitySlabs
{
    public class GetDisabilitySlabByIdHandler : IRequestHandler<GetDisabilitySlabByIdQuery, ResponseModel<DisabilitySlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDisabilitySlabByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetDisabilitySlabByIdHandler(IUnitofWork unitofWork, ILogger<GetDisabilitySlabByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<DisabilitySlabVM>> Handle(GetDisabilitySlabByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.DisabilitySlab.GetById(request.DisabilitySlabId)).Adapt<DisabilitySlabVM>();
            return new ResponseModel<DisabilitySlabVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

