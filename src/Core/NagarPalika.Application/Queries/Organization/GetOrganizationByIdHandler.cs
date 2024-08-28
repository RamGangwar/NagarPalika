using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Organization
{
    public class GetOrganizationByIdHandler : IRequestHandler<GetOrganizationByIdQuery, ResponseModel<OrganizationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetOrganizationByIdHandler> _logger;

        public GetOrganizationByIdHandler(IUnitofWork unitofWork, ILogger<GetOrganizationByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<OrganizationVM>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Organizations.GetById(request.OrganizationId)).Adapt<OrganizationVM>();
            return new ResponseModel<OrganizationVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
