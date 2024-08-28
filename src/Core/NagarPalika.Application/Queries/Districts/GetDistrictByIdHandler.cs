using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Districts
{
    public class GetDistrictByIdHandler : IRequestHandler<GetDistrictByIdQuery, ResponseModel<DistrictVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDistrictByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetDistrictByIdHandler(IUnitofWork unitofWork, ILogger<GetDistrictByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<DistrictVM>> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.Districts.GetById(request.DistrictId)).Adapt<DistrictVM>();
            depts.EmployeeName = (await _unitofWork.Employee.GetById(depts.CreatedBy)).EmployeeName;
            return new ResponseModel<DistrictVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
        }
    }
}

