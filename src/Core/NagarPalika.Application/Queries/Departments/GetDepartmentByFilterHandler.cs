using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Departments
{
    public class GetDepartmentByFilterHandler : IRequestHandler<GetDepartmentByFilterQuery, PagingModel<DepartmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDepartmentByFilterHandler> _logger;

        public GetDepartmentByFilterHandler(IUnitofWork unitofWork, ILogger<GetDepartmentByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DepartmentVM>> Handle(GetDepartmentByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Departments.GetByPaging(request);
            return new PagingModel<DepartmentVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
