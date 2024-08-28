using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetSubCategorys
{
    public class CreateAssetSubCategoryHandler : IRequestHandler<CreateAssetSubCategoryCommand, ResponseModel<AssetSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateAssetSubCategoryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAssetSubCategoryHandler(IUnitofWork unitofWork, ILogger<CreateAssetSubCategoryHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<AssetSubCategoryVM>> Handle(CreateAssetSubCategoryCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<AssetSubCategoryVM>();
            var query = new { AssetSubCategoryName = request.AssetSubCategoryName };
            var dept = await _unitofWork.AssetSubCategorys.GetByClause(query);
            if (dept == null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<AssetSubCategory>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.AssetSubCategorys.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.AssetSubCategorys.GetById(result);
                    response.Data = res.Adapt<AssetSubCategoryVM>();
                    response.Succeeded = true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded = false;
                response.Message = "AssetSubCategory Already Exists.";
                return response;
            }
        }
    }
}

