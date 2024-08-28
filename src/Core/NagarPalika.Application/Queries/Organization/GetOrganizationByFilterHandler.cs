using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Commands.Organization;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Organization
{
    public class GetOrganizationByFilterHandler : IRequestHandler<GetOrganizationByFilterQuery, PagingModel<OrganizationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetOrganizationByFilterHandler> _logger;

        public GetOrganizationByFilterHandler(IUnitofWork unitofWork, ILogger<GetOrganizationByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<OrganizationVM>> Handle(GetOrganizationByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Organizations.GetByPaging(request);
            return new PagingModel<OrganizationVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
