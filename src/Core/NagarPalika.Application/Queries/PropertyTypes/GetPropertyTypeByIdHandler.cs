using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.PropertyTypes
{
    public class GetPropertyTypeByIdHandler : IRequestHandler<GetPropertyTypeByIdQuery, ResponseModel<PropertyTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPropertyTypeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetPropertyTypeByIdHandler(IUnitofWork unitofWork, ILogger<GetPropertyTypeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<PropertyTypeVM>> Handle(GetPropertyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.PropertyType.GetById(request.PropertyTypeId)).Adapt<PropertyTypeVM>();
            return new ResponseModel<PropertyTypeVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

