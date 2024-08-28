using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.MonthlyRentalRates
{
    public class DeleteMonthlyRentalRateHandler : IRequestHandler<DeleteMonthlyRentalRateCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteMonthlyRentalRateHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteMonthlyRentalRateHandler(IUnitofWork unitofWork, ILogger<DeleteMonthlyRentalRateHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteMonthlyRentalRateCommand request, CancellationToken cancellationToken)
        {
            var dept = await _unitofWork.MonthlyRentalRate.GetById(request.MonthlyRentalRateId);
            if (dept != null && dept.MonthlyRentalRateId > 0)
            {
                var res = await _unitofWork.MonthlyRentalRate.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Monthly Rental Rate Not Found", Succeeded=false };
        }
}
}
