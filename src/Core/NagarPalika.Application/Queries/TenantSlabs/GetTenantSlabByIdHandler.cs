using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.TenantSlabs
{
    public class GetTenantSlabByIdHandler : IRequestHandler<GetTenantSlabByIdQuery, ResponseModel<TenantSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTenantSlabByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetTenantSlabByIdHandler(IUnitofWork unitofWork, ILogger<GetTenantSlabByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<TenantSlabVM>> Handle(GetTenantSlabByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.TenantSlab.GetById(request.TenantSlabId)).Adapt<TenantSlabVM>();
            return new ResponseModel<TenantSlabVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

