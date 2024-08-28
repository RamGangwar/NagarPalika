using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Helper;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Employees
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, ResponseModel<EmployeeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetEmployeeByIdHandler> _logger;
        private readonly IEmployeeProvider _userProvider;
        private readonly DomainServiceOptions _domainServiceOptions;
        public GetEmployeeByIdHandler(IUnitofWork unitofWork, ILogger<GetEmployeeByIdHandler> logger, IEmployeeProvider userProvider, IOptionsMonitor<DomainServiceOptions> domainServiceOptions)
        {

            _unitofWork = unitofWork;
            _logger = logger;
            _userProvider = userProvider;
            _domainServiceOptions = domainServiceOptions.CurrentValue;
        }
        public async Task<ResponseModel<EmployeeVM>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            if (request.UserId == 0)
            {
                request.UserId = _userProvider.EmployeeId;
            }

            var usermodel = (await _unitofWork.Employee.GetById(request.UserId)).Adapt<EmployeeVM>();
            return new ResponseModel<EmployeeVM> { Data = usermodel, };
        }
    }
}
