using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.AssetCategorys
{
    public class GetAssetCategoryByIdHandler : IRequestHandler<GetAssetCategoryByIdQuery, ResponseModel<AssetCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAssetCategoryByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetAssetCategoryByIdHandler(IUnitofWork unitofWork, ILogger<GetAssetCategoryByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<AssetCategoryVM>> Handle(GetAssetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.AssetCategorys.GetById(request.AssetCategoryId)).Adapt<AssetCategoryVM>();
            return new ResponseModel<AssetCategoryVM>
            {
                Data = depts,
                Succeeded = depts != null ? true : false,
                Message = depts != null ? "Record Found" : "No Record Found"
            };
            
        }
    }
}

