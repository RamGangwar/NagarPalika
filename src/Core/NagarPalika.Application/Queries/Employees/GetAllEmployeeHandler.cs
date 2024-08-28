using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Employees
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, PagingModel<EmployeeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAllEmployeeHandler> _logger;
        public GetAllEmployeeHandler(IUnitofWork unitofWork, ILogger<GetAllEmployeeHandler> logger)
        {

            _unitofWork = unitofWork;
            _logger = logger;
        }
        public async Task<PagingModel<EmployeeVM>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var result = await _unitofWork.Employee.GetByPaging(request);

            return new PagingModel<EmployeeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
