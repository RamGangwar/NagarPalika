using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Role
{
    public class CreateRolesHandler : IRequestHandler<CreateRolesCommand, ResponseModel<RolesVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRolesHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRolesHandler(IUnitofWork unitofWork, ILogger<CreateRolesHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<RolesVM>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RolesVM>();
            var dept = await _unitofWork.Roles.GetByClause(new { RoleName = request.RoleName });
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<Roles>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Roles.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Roles.GetById(result);
                    response.Data = res.Adapt<RolesVM>();
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
                response.Message = "Role Already Exists.";
                return response;
            }
        }
    }
}
