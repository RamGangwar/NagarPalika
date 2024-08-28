using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.MonthlyRentalRates
{
    public class GetMonthlyRentalRateByIdHandler : IRequestHandler<GetMonthlyRentalRateByIdQuery, ResponseModel<MonthlyRentalRateVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetMonthlyRentalRateByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetMonthlyRentalRateByIdHandler(IUnitofWork unitofWork, ILogger<GetMonthlyRentalRateByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<MonthlyRentalRateVM>> Handle(GetMonthlyRentalRateByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.MonthlyRentalRate.GetById(request.MonthlyRentalRateId)).Adapt<MonthlyRentalRateVM>();
            return new ResponseModel<MonthlyRentalRateVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

