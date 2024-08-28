using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.TariffPlans
{
    public class UpdateTariffPlanHandler : IRequestHandler<UpdateTariffPlanCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTariffPlanHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateTariffPlanHandler(IUnitofWork unitofWork, ILogger<UpdateTariffPlanHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateTariffPlanCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType = request.PropertyType, TariffPlanId_neq = request.TariffPlanId };
            var deptDuplicate = await _unitofWork.TariffPlan.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "TariffPlan Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.TariffPlan.GetById(request.TariffPlanId);
            if (dept != null && dept.TariffPlanId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.PropertyType = request.PropertyType;
                dept.ARV_NonAssessed = request.ARV_NonAssessed;
                dept.ARV_Assessed = request.ARV_Assessed;
                dept.HouseTax_LessThan = request.HouseTax_LessThan;
                dept.HouseTax_MoreThan = request.HouseTax_MoreThan;
                dept.HouseTax_LessThan_ForNonAssessed = request.HouseTax_LessThan_ForNonAssessed;
                dept.HouseTax_MoreThan_ForNonAssessed = request.HouseTax_MoreThan_ForNonAssessed;
                dept.WaterTax_LessThan = request.WaterTax_LessThan;
                dept.WaterTax_MoreThan = request.WaterTax_MoreThan;
                dept.WaterTax_LessThan_ForNonAssessed = request.WaterTax_LessThan_ForNonAssessed;
                dept.WaterTax_MoreThan_ForNonAssessed = request.WaterTax_MoreThan_ForNonAssessed;
                dept.SewerTax_LessThan = request.SewerTax_LessThan;
                dept.SewerTax_MoreThan = request.SewerTax_MoreThan;
                dept.SewerTax_LessThan_ForNonAssessed = request.SewerTax_LessThan_ForNonAssessed;
                dept.SewerTax_MoreThan_ForNonAssessed = request.SewerTax_MoreThan_ForNonAssessed;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.TariffPlan.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
