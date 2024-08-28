using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Commands.User;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Employees
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateEmployeeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommonMethod _commonMethod;
        public UpdateEmployeeHandler(IUnitofWork unitofWork, ILogger<UpdateEmployeeHandler> logger, IMediator mediator, ICommonMethod commonMethod, IHttpContextAccessor httpContextAccessor)
        {

            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _commonMethod = commonMethod;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _unitofWork.Employee.GetById(command.EmployeeId);
            if (employee != null && employee.EmployeeId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

                employee.EmployeeName = command.EmployeeName;
                employee.FatherName = command.FatherName;
                employee.MobileNo = command.MobileNo;
                employee.AlternateMobileNo = command.AlternateMobileNo;
                employee.EmailId = command.EmailId;
                employee.FullAddress = command.FullAddress;
                employee.OrganizationId = command.OrganizationId;
                employee.DepartmentId = command.DepartmentId;
                employee.DesignationId = command.DesignationId;
                employee.Level = command.Level;
                employee.ReportingEmployeeId = command.ReportingEmployeeId;
                employee.RoleId = command.RoleId;
                employee.UserTypeId = command.UserTypeId;
                if (command.ProfilePicURL != null && command.ProfilePicURL.Length > 0)
                {
                    employee.ProfilePicURL = await _commonMethod.SaveAttachment(command.EmployeeId, "Profile", command.ProfilePicURL);
                }
                employee.ModifyBy = Convert.ToInt32(empId);
                employee.ModifyOn = DateTime.Now;
                var res = await _unitofWork.Employee.Update(employee);
                if (res)
                {
                    return new ResponseModel { Message = "Updated successfully", Succeeded=true };
                }
                return new ResponseModel { Message = "Failed to update", Succeeded=false };
            }

            return new ResponseModel { Message = "Invalid Employee", Succeeded=false };
        }
    }
}
