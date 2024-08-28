using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Ward
{
    public class GetWardsByIdHandler : IRequestHandler<GetWardsByIdQuery, ResponseModel<WardsVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetWardsByIdHandler> _logger;

        public GetWardsByIdHandler(IUnitofWork unitofWork, ILogger<GetWardsByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<WardsVM>> Handle(GetWardsByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Wards.GetById(request.WardId)).Adapt<WardsVM>();
            return new ResponseModel<WardsVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
