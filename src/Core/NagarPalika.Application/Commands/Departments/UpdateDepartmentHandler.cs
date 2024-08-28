using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Departments
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDepartmentHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateDepartmentHandler(IUnitofWork unitofWork, ILogger<UpdateDepartmentHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { DepartmentName = request.DepartmentName, DepartmentId_neq = request.DepartmentId };
            var deptDuplicate = await _unitofWork.Departments.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Department Already Exists", Succeeded=false };
            }
            var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            var dept = await _unitofWork.Departments.GetById(request.DepartmentId);
            if (dept != null && dept.DepartmentId > 0)
            {
                dept.DepartmentName = request.DepartmentName;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.Departments.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
