using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.TariffPlans
{
    public class DeleteTariffPlanHandler : IRequestHandler<DeleteTariffPlanCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTariffPlanHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteTariffPlanHandler(IUnitofWork unitofWork, ILogger<DeleteTariffPlanHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteTariffPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.TariffPlan.GetById(request.TariffPlanId);
            if (dept != null && dept.TariffPlanId > 0)
            {
                var res = await _unitofWork.TariffPlan.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "TariffPlan Not Found", Succeeded=false };
        }
}
}
