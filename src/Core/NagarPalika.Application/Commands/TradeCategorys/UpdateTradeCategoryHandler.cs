using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.TradeCategorys
{
    public class UpdateTradeCategoryHandler : IRequestHandler<UpdateTradeCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTradeCategoryHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateTradeCategoryHandler(IUnitofWork unitofWork, ILogger<UpdateTradeCategoryHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateTradeCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { TradeCategoryName = request.TradeCategoryName, TradeCategoryId_neq = request.TradeCategoryId };
            var deptDuplicate = await _unitofWork.TradeCategory.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Trade Category Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.TradeCategory.GetById(request.TradeCategoryId);
            if (dept != null && dept.TradeCategoryId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.TradeCategoryName = request.TradeCategoryName;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.TradeCategory.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}

