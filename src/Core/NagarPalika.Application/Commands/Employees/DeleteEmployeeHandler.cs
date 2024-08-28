using MediatR;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Employees
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        public DeleteEmployeeHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitofWork.Employee.GetById(request.EmployeeId);
            if (employee != null && employee.EmployeeId > 0)
            {
                var res = await _unitofWork.Employee.Delete(employee);
                if (res)
                {
                    return new ResponseModel { Message = "Deleted successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Invalid Employee", Succeeded=false};
        }
    }
}
