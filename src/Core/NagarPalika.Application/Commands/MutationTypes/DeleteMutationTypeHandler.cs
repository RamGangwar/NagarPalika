using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.MutationTypes
{
    public class DeleteMutationTypeHandler : IRequestHandler<DeleteMutationTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteMutationTypeHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteMutationTypeHandler(IUnitofWork unitofWork, ILogger<DeleteMutationTypeHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteMutationTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.MutationType.GetById(request.MutationTypeId);
            if (dept != null && dept.MutationTypeId > 0)
            {
                var res = await _unitofWork.MutationType.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Mutation Type Not Found", Succeeded=false };
        }
}
}
