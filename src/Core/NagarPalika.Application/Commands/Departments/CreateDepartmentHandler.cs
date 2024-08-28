using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Departments
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, ResponseModel<DepartmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDepartmentHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateDepartmentHandler(IUnitofWork unitofWork, ILogger<CreateDepartmentHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DepartmentVM>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DepartmentVM>();
            var query = new { DepartmentName = request.DepartmentName };
            var dept = await _unitofWork.Departments.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<Department>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Departments.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Departments.GetById(result);
                    response.Data = res.Adapt<DepartmentVM>();
                    response.Succeeded=true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded=false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded=false;
                response.Message = "Department Already Exists.";
                return response;
            }
        }
    }
}
