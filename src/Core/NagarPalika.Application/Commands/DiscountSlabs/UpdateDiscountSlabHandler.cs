using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DiscountSlabs
{
    public class UpdateDiscountSlabHandler : IRequestHandler<UpdateDiscountSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDiscountSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateDiscountSlabHandler(IUnitofWork unitofWork, ILogger<UpdateDiscountSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateDiscountSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType = request.PropertyType, StartDate = request.StartDate, EndDate = request.EndDate, DiscountSlabId_neq = request.DiscountSlabId };
            var deptDuplicate = await _unitofWork.DiscountSlab.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Discount Slab Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.DiscountSlab.GetById(request.DiscountSlabId);
            if (dept != null && dept.DiscountSlabId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.StartDate = request.StartDate;
                dept.EndDate = request.EndDate;
                dept.Value = request.Value;
                dept.PropertyType = request.PropertyType;
                var result = await _unitofWork.DiscountSlab.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
