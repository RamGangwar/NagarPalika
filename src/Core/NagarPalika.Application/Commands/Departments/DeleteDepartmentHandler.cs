using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Departments
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDepartmentHandler> _logger;

        public DeleteDepartmentHandler(IUnitofWork unitofWork, ILogger<DeleteDepartmentHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Departments.GetById(request.DepartmentId);
            if (dept != null && dept.DepartmentId > 0)
            {
                var res = await _unitofWork.Departments.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Department Not Found", Succeeded=false };
        }
    }
}
