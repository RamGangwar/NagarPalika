using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.TradeRegistrations
{
    public class UpdateTradeRegistrationHandler : IRequestHandler<UpdateTradeRegistrationCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTradeRegistrationHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateTradeRegistrationHandler(IUnitofWork unitofWork, ILogger<UpdateTradeRegistrationHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateTradeRegistrationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { TradeRegistrationName = request.TradeName, TradeRegistrationId_neq = request.TradeRegistrationId };
            var deptDuplicate = await _unitofWork.TradeRegistration.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "TradeRegistration Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.TradeRegistration.GetById(request.TradeRegistrationId);
            if (dept != null && dept.TradeRegistrationId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.TradeCode = request.TradeCode;
                dept.ApplicationType = request.ApplicationType;
                dept.OwnerName = request.OwnerName;
                dept.FatherName = request.FatherName;
                dept.MobileNo = request.MobileNo;
                dept.Email = request.Email;
                dept.Religion = request.Religion;
                dept.IdProofType = request.IdProofType;
                dept.IdProofNo = request.IdProofNo;
                dept.Gender = request.Gender;
                dept.HouseNo = request.HouseNo;
                dept.TradeName = request.TradeName;
                dept.TradeAddress = request.TradeAddress;
                dept.ZoneId = request.ZoneId;
                dept.WardId = request.WardId;
                dept.LocalityId = request.LocalityId;
                dept.TradeCategoryId = request.TradeCategoryId;
                dept.TradeSubCategoryId = request.TradeSubCategoryId;
                dept.ARVEffectedDate = request.ARVEffectedDate;
                dept.Arrear = request.Arrear;
                dept.ArrearFrom = request.ArrearFrom;
                dept.ArrearTill = request.ArrearTill;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.TradeRegistration.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

