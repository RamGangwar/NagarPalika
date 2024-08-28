using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DisabilitySlabs
{
    public class GetDisabilitySlabByFilterHandler : IRequestHandler<GetDisabilitySlabByFilterQuery, PagingModel<DisabilitySlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDisabilitySlabByFilterHandler> _logger;

        public GetDisabilitySlabByFilterHandler(IUnitofWork unitofWork, ILogger<GetDisabilitySlabByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DisabilitySlabVM>> Handle(GetDisabilitySlabByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.DisabilitySlab.GetByPaging(request);
            return new PagingModel<DisabilitySlabVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

