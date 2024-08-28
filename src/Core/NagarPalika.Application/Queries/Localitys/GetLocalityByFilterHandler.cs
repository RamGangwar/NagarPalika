using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Queries.Organization;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Localitys
{
    public class GetLocalityByFilterHandler : IRequestHandler<GetLocalityByFilterQuery, PagingModel<LocalityVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetLocalityByFilterHandler> _logger;

        public GetLocalityByFilterHandler(IUnitofWork unitofWork, ILogger<GetLocalityByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<LocalityVM>> Handle(GetLocalityByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Locality.GetByPaging(request);
            return new PagingModel<LocalityVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
