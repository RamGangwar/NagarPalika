using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TenantSlabs
{
    public class GetTenantSlabByFilterHandler : IRequestHandler<GetTenantSlabByFilterQuery, PagingModel<TenantSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetTenantSlabByFilterHandler> _logger;

        public GetTenantSlabByFilterHandler(IUnitofWork unitofWork, ILogger<GetTenantSlabByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<TenantSlabVM>> Handle(GetTenantSlabByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.TenantSlab.GetByPaging(request);
            return new PagingModel<TenantSlabVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

