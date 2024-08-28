using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Zone
{
    public class GetZonesByIdHandler : IRequestHandler<GetZonesByIdQuery, ResponseModel<ZonesVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetZonesByIdHandler> _logger;

        public GetZonesByIdHandler(IUnitofWork unitofWork, ILogger<GetZonesByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<ZonesVM>> Handle(GetZonesByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Zones.GetById(request.ZoneId)).Adapt<ZonesVM>();
            return new ResponseModel<ZonesVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
