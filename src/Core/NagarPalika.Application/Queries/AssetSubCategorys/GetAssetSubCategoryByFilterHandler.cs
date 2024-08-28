using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetSubCategorys
{
    public class GetAssetSubCategoryByFilterHandler : IRequestHandler<GetAssetSubCategoryByFilterQuery, PagingModel<AssetSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAssetSubCategoryByFilterHandler> _logger;

        public GetAssetSubCategoryByFilterHandler(IUnitofWork unitofWork, ILogger<GetAssetSubCategoryByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<AssetSubCategoryVM>> Handle(GetAssetSubCategoryByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.AssetSubCategorys.GetByPaging(request);
            return new PagingModel<AssetSubCategoryVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault()!.TotalRecord : 0);

        }
    }
}

