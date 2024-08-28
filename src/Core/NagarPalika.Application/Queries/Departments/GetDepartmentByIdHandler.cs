using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Departments
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, ResponseModel<DepartmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDepartmentByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetDepartmentByIdHandler(IUnitofWork unitofWork, ILogger<GetDepartmentByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<DepartmentVM>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Departments.GetById(request.DepartmentId)).Adapt<DepartmentVM>();
            return new ResponseModel<DepartmentVM> 
            { 
                Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
            };
        }
    }
}
