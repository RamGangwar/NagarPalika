using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetCategorys
{
    public class CreateAssetCategoryHandler : IRequestHandler<CreateAssetCategoryCommand, ResponseModel<AssetCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateAssetCategoryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateAssetCategoryHandler(IUnitofWork unitofWork, ILogger<CreateAssetCategoryHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<AssetCategoryVM>> Handle(CreateAssetCategoryCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<AssetCategoryVM>();
            var query = new { AssetCategoryName = request.AssetCategoryName };
            var dept = await _unitofWork.AssetCategorys.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<AssetCategory>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.AssetCategorys.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.AssetCategorys.GetById(result);
                    response.Data = res.Adapt<AssetCategoryVM>();
                    response.Succeeded=true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded=false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded=false;
                response.Message = "Asset Category Already Exists.";
                return response;
            }
        }
    }
}

