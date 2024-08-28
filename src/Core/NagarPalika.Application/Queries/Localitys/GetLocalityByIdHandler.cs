using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Localitys
{
    public class GetLocalityByIdHandler : IRequestHandler<GetLocalityByIdQuery, ResponseModel<LocalityVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetLocalityByIdHandler> _logger;

        public GetLocalityByIdHandler(IUnitofWork unitofWork, ILogger<GetLocalityByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<LocalityVM>> Handle(GetLocalityByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Locality.GetById(request.LocalityId)).Adapt<LocalityVM>();
            return new ResponseModel<LocalityVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
