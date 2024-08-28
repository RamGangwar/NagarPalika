using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DiscountSlabs
{
    public class GetDiscountSlabByFilterHandler : IRequestHandler<GetDiscountSlabByFilterQuery, PagingModel<DiscountSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetDiscountSlabByFilterHandler> _logger;

        public GetDiscountSlabByFilterHandler(IUnitofWork unitofWork, ILogger<GetDiscountSlabByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<DiscountSlabVM>> Handle(GetDiscountSlabByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.DiscountSlab.GetByPaging(request);
            return new PagingModel<DiscountSlabVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

