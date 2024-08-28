using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Commands.Departments;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Designations
{
    public class UpdateDesignationHandler : IRequestHandler<UpdateDesignationCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDesignationHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateDesignationHandler(IUnitofWork unitofWork, ILogger<UpdateDesignationHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            var query = new { DesignationName = request.DesignationName, DesignationId_neq = request.DesignationId };
            var deptDuplicate = await _unitofWork.Designations.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Designation Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.Designations.GetById(request.DesignationId);
            if (dept != null && dept.DesignationId > 0)
            {
                dept.DesignationName = request.DesignationName;
                dept.DesignationLevel = request.DesignationLevel;
                //dept.IsActive = request.IsActive;
                dept.ModifyBy= Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.Designations.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
