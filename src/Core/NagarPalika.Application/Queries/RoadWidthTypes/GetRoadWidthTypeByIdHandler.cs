using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.RoadWidthTypes
{
    public class GetRoadWidthTypeByIdHandler : IRequestHandler<GetRoadWidthTypeByIdQuery, ResponseModel<RoadWidthTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRoadWidthTypeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetRoadWidthTypeByIdHandler(IUnitofWork unitofWork, ILogger<GetRoadWidthTypeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RoadWidthTypeVM>> Handle(GetRoadWidthTypeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.RoadWidthType.GetById(request.RoadWidthTypeId)).Adapt<RoadWidthTypeVM>();
            return new ResponseModel<RoadWidthTypeVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

