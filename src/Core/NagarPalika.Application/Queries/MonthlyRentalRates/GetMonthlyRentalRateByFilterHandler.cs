using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MonthlyRentalRates
{
    public class GetMonthlyRentalRateByFilterHandler : IRequestHandler<GetMonthlyRentalRateByFilterQuery, PagingModel<MonthlyRentalRateVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetMonthlyRentalRateByFilterHandler> _logger;

        public GetMonthlyRentalRateByFilterHandler(IUnitofWork unitofWork, ILogger<GetMonthlyRentalRateByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<MonthlyRentalRateVM>> Handle(GetMonthlyRentalRateByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.MonthlyRentalRate.GetByPaging(request);
            return new PagingModel<MonthlyRentalRateVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

