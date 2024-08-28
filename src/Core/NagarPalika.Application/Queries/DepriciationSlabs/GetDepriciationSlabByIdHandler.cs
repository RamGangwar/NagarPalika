using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.DepriciationSlabs
{
    public class GetDepriciationSlabByIdHandler : IRequestHandler<GetDepriciationSlabByIdQuery, ResponseModel<DepriciationSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDepriciationSlabByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetDepriciationSlabByIdHandler(IUnitofWork unitofWork, ILogger<GetDepriciationSlabByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<DepriciationSlabVM>> Handle(GetDepriciationSlabByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.DepriciationSlab.GetById(request.DepriciationSlabId)).Adapt<DepriciationSlabVM>();
            return new ResponseModel<DepriciationSlabVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

