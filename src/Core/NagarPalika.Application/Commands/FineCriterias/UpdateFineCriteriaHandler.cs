using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.FineCriterias
{
    public class UpdateFineCriteriaHandler : IRequestHandler<UpdateFineCriteriaCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateFineCriteriaHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateFineCriteriaHandler(IUnitofWork unitofWork, ILogger<UpdateFineCriteriaHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateFineCriteriaCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType = request.PropertyType, FineCriteriaId_neq = request.FineCriteriaId };
            var deptDuplicate = await _unitofWork.FineCriteria.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Fine Criteria Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.FineCriteria.GetById(request.FineCriteriaId);
            if (dept != null && dept.FineCriteriaId > 0)
            {
                
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.PropertyType = request.PropertyType;
                dept.ARVThreshold = request.ARVThreshold;
                dept.HouseTax_LessThan = request.HouseTax_LessThan;
                dept.HouseTax_MoreThan = request.HouseTax_MoreThan;
                dept.WaterTax_LessThan = request.WaterTax_LessThan;
                dept.WaterTax_MoreThan = request.WaterTax_MoreThan;
                dept.SewerTax_LessThan = request.SewerTax_LessThan;
                dept.SewerTax_MoreThan = request.SewerTax_MoreThan;
                var result = await _unitofWork.FineCriteria.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
