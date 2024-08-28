using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.AssetCategorys
{
    public class UpdateAssetCategoryHandler : IRequestHandler<UpdateAssetCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateAssetCategoryHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateAssetCategoryHandler(IUnitofWork unitofWork, ILogger<UpdateAssetCategoryHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateAssetCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { AssetCategoryName = request.AssetCategoryName, AssetCategoryId_neq = request.AssetCategoryId };
            var deptDuplicate = await _unitofWork.AssetCategorys.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "AssetCategory Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.AssetCategorys.GetById(request.AssetCategoryId);
            if (dept != null && dept.AssetCategoryId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.AssetCategoryName = request.AssetCategoryName;
                var result = await _unitofWork.AssetCategorys.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}

