using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.ConstructionTypes
{
    public class GetConstructionTypeByIdHandler : IRequestHandler<GetConstructionTypeByIdQuery, ResponseModel<ConstructionTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetConstructionTypeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetConstructionTypeByIdHandler(IUnitofWork unitofWork, ILogger<GetConstructionTypeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<ConstructionTypeVM>> Handle(GetConstructionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.ConstructionType.GetById(request.ConstructionTypeId)).Adapt<ConstructionTypeVM>();
            return new ResponseModel<ConstructionTypeVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

