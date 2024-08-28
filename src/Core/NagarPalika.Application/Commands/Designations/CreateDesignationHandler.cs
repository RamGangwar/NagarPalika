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

namespace NagarPalika.Application.Commands.Designations
{
    public class CreateDesignationHandler : IRequestHandler<CreateDesignationCommand, ResponseModel<DesignationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDesignationHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateDesignationHandler(IUnitofWork unitofWork, ILogger<CreateDesignationHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DesignationVM>> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DesignationVM>();
            var dept = await _unitofWork.Designations.GetByClause(new { DesignationName = request.DesignationName });
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<Designation>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Designations.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Designations.GetById(result);
                    response.Data = res.Adapt<DesignationVM>();
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
                response.Message = "Designation Already Exists.";
                return response;
            }
        }
    }
}
