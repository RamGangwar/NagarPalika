using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
namespace NagarPalika.Application.Commands.ConstructionTypes
{
    public class DeleteConstructionTypeHandler : IRequestHandler<DeleteConstructionTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteConstructionTypeHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteConstructionTypeHandler(IUnitofWork unitofWork, ILogger<DeleteConstructionTypeHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteConstructionTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.ConstructionType.GetById(request.ConstructionTypeId);
            if (dept != null && dept.ConstructionTypeId > 0)
            {
                var res = await _unitofWork.ConstructionType.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "ConstructionType Not Found", Succeeded=false };
        }
}
}
