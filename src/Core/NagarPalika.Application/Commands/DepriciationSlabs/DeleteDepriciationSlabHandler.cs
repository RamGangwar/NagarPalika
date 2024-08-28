using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DepriciationSlabs
{
    public class DeleteDepriciationSlabHandler : IRequestHandler<DeleteDepriciationSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDepriciationSlabHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteDepriciationSlabHandler(IUnitofWork unitofWork, ILogger<DeleteDepriciationSlabHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteDepriciationSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.DepriciationSlab.GetById(request.DepriciationSlabId);
            if (dept != null && dept.DepriciationSlabId > 0)
            {
                var res = await _unitofWork.DepriciationSlab.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Depriciation Slab Not Found", Succeeded=false };
        }
}
}
