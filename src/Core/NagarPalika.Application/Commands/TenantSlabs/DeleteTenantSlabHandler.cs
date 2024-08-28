using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.TenantSlabs
{
    public class DeleteTenantSlabHandler : IRequestHandler<DeleteTenantSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTenantSlabHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteTenantSlabHandler(IUnitofWork unitofWork, ILogger<DeleteTenantSlabHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteTenantSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.TenantSlab.GetById(request.TenantSlabId);
            if (dept != null && dept.TenantSlabId > 0)
            {
                var res = await _unitofWork.TenantSlab.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Tenant Slab Not Found", Succeeded=false };
        }
}
}
