using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Districts
{
    public class GetDistrictByFilterHandler : IRequestHandler<GetDistrictByFilterQuery, PagingModel<DistrictVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDistrictByFilterHandler> _logger;

        public GetDistrictByFilterHandler(IUnitofWork unitofWork, ILogger<GetDistrictByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DistrictVM>> Handle(GetDistrictByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Districts.GetByPaging(request);
            return new PagingModel<DistrictVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

