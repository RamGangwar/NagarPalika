using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Designations
{
    public class GetDesignationByIdHandler : IRequestHandler<GetDesignationByIdQuery, ResponseModel<DesignationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDesignationByIdHandler> _logger;

        public GetDesignationByIdHandler(IUnitofWork unitofWork, ILogger<GetDesignationByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<DesignationVM>> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Designations.GetById(request.DesignationId)).Adapt<DesignationVM>();
            return new ResponseModel<DesignationVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
