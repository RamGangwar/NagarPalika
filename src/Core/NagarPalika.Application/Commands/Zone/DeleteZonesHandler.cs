using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Zone
{
    public class DeleteZonesHandler : IRequestHandler<DeleteZonesCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteZonesHandler> _logger;


        public DeleteZonesHandler(IUnitofWork unitofWork, ILogger<DeleteZonesHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteZonesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Zones.GetById(request.ZoneId);
            if (dept != null && dept.ZoneId > 0)
            {
                var res = await _unitofWork.Zones.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Zone Not Found", Succeeded=false };
        }
    }
}
