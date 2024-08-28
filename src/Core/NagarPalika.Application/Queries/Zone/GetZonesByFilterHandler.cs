using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Zone
{
    public class GetZonesByFilterHandler : IRequestHandler<GetZonesByFilterQuery, PagingModel<ZonesVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetZonesByFilterHandler> _logger;

        public GetZonesByFilterHandler(IUnitofWork unitofWork, ILogger<GetZonesByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<ZonesVM>> Handle(GetZonesByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Zones.GetByPaging(request);
            return new PagingModel<ZonesVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
