using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.RoadWidthTypes
{
    public class DeleteRoadWidthTypeHandler : IRequestHandler<DeleteRoadWidthTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteRoadWidthTypeHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteRoadWidthTypeHandler(IUnitofWork unitofWork, ILogger<DeleteRoadWidthTypeHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteRoadWidthTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.RoadWidthType.GetById(request.RoadWidthTypeId);
            if (dept != null && dept.RoadWidthTypeId > 0)
            {
                var res = await _unitofWork.RoadWidthType.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "RoadWidthType Not Found", Succeeded=false };
        }
}
}
