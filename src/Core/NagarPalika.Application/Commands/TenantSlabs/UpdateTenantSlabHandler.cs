using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.TenantSlabs
{
    public class UpdateTenantSlabHandler : IRequestHandler<UpdateTenantSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTenantSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateTenantSlabHandler(IUnitofWork unitofWork, ILogger<UpdateTenantSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateTenantSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType = request.PropertyType, TenantSlabId_neq = request.TenantSlabId };
            var deptDuplicate = await _unitofWork.TenantSlab.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Tenant Slab Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.TenantSlab.GetById(request.TenantSlabId);
            if (dept != null && dept.TenantSlabId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.PropertyType = request.PropertyType;
                dept.SlabStartValue = request.SlabStartValue;
                dept.SlabEndValue = request.SlabEndValue;
                dept.Value = request.Value;
                var result = await _unitofWork.TenantSlab.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
