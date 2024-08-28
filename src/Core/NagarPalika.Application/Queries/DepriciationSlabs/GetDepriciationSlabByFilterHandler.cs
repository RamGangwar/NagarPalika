using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DepriciationSlabs
{
    public class GetDepriciationSlabByFilterHandler : IRequestHandler<GetDepriciationSlabByFilterQuery, PagingModel<DepriciationSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDepriciationSlabByFilterHandler> _logger;

        public GetDepriciationSlabByFilterHandler(IUnitofWork unitofWork, ILogger<GetDepriciationSlabByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DepriciationSlabVM>> Handle(GetDepriciationSlabByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.DepriciationSlab.GetByPaging(request);
            return new PagingModel<DepriciationSlabVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

