using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.AssetSubCategorys
{
    public class UpdateAssetSubCategoryHandler : IRequestHandler<UpdateAssetSubCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateAssetSubCategoryHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateAssetSubCategoryHandler(IUnitofWork unitofWork, ILogger<UpdateAssetSubCategoryHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateAssetSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { AssetSubCategoryName = request.AssetSubCategoryName, AssetSubCategoryId_neq = request.AssetSubCategoryId };
            var deptDuplicate = await _unitofWork.AssetSubCategorys.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "AssetSubCategory Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.AssetSubCategorys.GetById(request.AssetSubCategoryId);
            if (dept != null && dept.AssetSubCategoryId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.AssetSubCategoryName = request.AssetSubCategoryName;
                dept.AssetCategoryId = request.AssetCategoryId;
                var result = await _unitofWork.AssetSubCategorys.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

