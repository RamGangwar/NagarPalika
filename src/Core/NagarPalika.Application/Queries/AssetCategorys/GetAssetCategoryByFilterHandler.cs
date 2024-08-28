using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetCategorys
{
    public class GetAssetCategoryByFilterHandler : IRequestHandler<GetAssetCategoryByFilterQuery, PagingModel<AssetCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAssetCategoryByFilterHandler> _logger;

        public GetAssetCategoryByFilterHandler(IUnitofWork unitofWork, ILogger<GetAssetCategoryByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<AssetCategoryVM>> Handle(GetAssetCategoryByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.AssetCategorys.GetByPaging(request);
            return new PagingModel<AssetCategoryVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);
        }
    }
}

