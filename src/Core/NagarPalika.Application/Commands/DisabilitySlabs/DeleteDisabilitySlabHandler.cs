using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DisabilitySlabs
{
    public class DeleteDisabilitySlabHandler : IRequestHandler<DeleteDisabilitySlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDisabilitySlabHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteDisabilitySlabHandler(IUnitofWork unitofWork, ILogger<DeleteDisabilitySlabHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteDisabilitySlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.DisabilitySlab.GetById(request.DisabilitySlabId);
            if (dept != null && dept.DisabilitySlabId > 0)
            {
                var res = await _unitofWork.DisabilitySlab.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Disability Slab Not Found", Succeeded=false };
        }
}
}
