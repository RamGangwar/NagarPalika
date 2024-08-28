using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.TradeSubCategorys
{
    public class UpdateTradeSubCategoryHandler : IRequestHandler<UpdateTradeSubCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTradeSubCategoryHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateTradeSubCategoryHandler(IUnitofWork unitofWork, ILogger<UpdateTradeSubCategoryHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateTradeSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { TradeSubCategoryName = request.TradeSubCategoryName, TradeSubCategoryId_neq = request.TradeSubCategoryId };
            var deptDuplicate = await _unitofWork.TradeSubCategory.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "TradeSubCategory Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.TradeSubCategory.GetById(request.TradeSubCategoryId);
            if (dept != null && dept.TradeSubCategoryId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.TradeSubCategoryName = request.TradeSubCategoryName;
                dept.TermAndCondition = request.TermAndCondition;
                dept.Fees = request.Fees;
                dept.TradeCategoryId = request.TradeCategoryId;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.TradeSubCategory.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}

