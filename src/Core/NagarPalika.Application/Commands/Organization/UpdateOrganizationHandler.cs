using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Commands.Designations;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Organization
{
    public class UpdateOrganizationHandler : IRequestHandler<UpdateOrganizationCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateOrganizationHandler> _logger;

        public UpdateOrganizationHandler(IUnitofWork unitofWork, ILogger<UpdateOrganizationHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { OrgName = request.OrgName , OrgId_neq = request.OrgId };
            var duplicate = await _unitofWork.Organizations.GetByClause(query);
            if (duplicate != null)
            {
                return new ResponseModel { Message = "Organization Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.Organizations.GetById(request.OrgId);
            if (dept != null && dept.OrgId > 0)
            {
                dept = request.Adapt<Organizations>();
                var result = await _unitofWork.Organizations.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
