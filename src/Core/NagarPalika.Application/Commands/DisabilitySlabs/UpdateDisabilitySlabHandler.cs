using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.DisabilitySlabs
{
    public class UpdateDisabilitySlabHandler : IRequestHandler<UpdateDisabilitySlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDisabilitySlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateDisabilitySlabHandler(IUnitofWork unitofWork, ILogger<UpdateDisabilitySlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateDisabilitySlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType = request.PropertyType, StartValue = request.StartValue, EndValue = request.EndValue, DisabilitySlabId_neq = request.DisabilitySlabId };
            var deptDuplicate = await _unitofWork.DisabilitySlab.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Disability Slab Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.DisabilitySlab.GetById(request.DisabilitySlabId);
            if (dept != null && dept.DisabilitySlabId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.StartValue = request.StartValue;
                dept.EndValue = request.EndValue;
                dept.Value = request.Value;
                dept.PropertyType = request.PropertyType;
                var result = await _unitofWork.DisabilitySlab.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
