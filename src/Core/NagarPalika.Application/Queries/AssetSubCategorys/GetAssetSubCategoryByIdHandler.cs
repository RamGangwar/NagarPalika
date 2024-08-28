using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.AssetSubCategorys
{
    public class GetAssetSubCategoryByIdHandler : IRequestHandler<GetAssetSubCategoryByIdQuery, ResponseModel<AssetSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAssetSubCategoryByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetAssetSubCategoryByIdHandler(IUnitofWork unitofWork, ILogger<GetAssetSubCategoryByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<AssetSubCategoryVM>> Handle(GetAssetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.AssetSubCategorys.GetById(request.AssetSubCategoryId)).Adapt<AssetSubCategoryVM>();
            return new ResponseModel<AssetSubCategoryVM> 
            { 
              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
           };
            throw new NotImplementedException();
        }
    }
}

