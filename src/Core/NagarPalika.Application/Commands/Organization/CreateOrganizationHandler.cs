using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.Organization
{
    public class CreateOrganizationHandler : IRequestHandler<CreateOrganizationCommand, ResponseModel<OrganizationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateOrganizationHandler> _logger;

        public CreateOrganizationHandler(IUnitofWork unitofWork, ILogger<CreateOrganizationHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<OrganizationVM>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<OrganizationVM>();
            var dept = await _unitofWork.Organizations.GetByClause(new { OrgName = request.OrgName });
            if (dept==null)
            {
                var model = request.Adapt<Organizations>();
                var result = await _unitofWork.Organizations.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Organizations.GetById(result);
                    response.Data = res.Adapt<OrganizationVM>();
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
                response.Message = "Organization Already Exists.";
                return response;
            }
        }
    }
}
