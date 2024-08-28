using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.ConstructionTypes
{
    public class UpdateConstructionTypeHandler : IRequestHandler<UpdateConstructionTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateConstructionTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateConstructionTypeHandler(IUnitofWork unitofWork, ILogger<UpdateConstructionTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateConstructionTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { ConstructionTypeName = request.ConstructionTypeName, ConstructionTypeId_neq = request.ConstructionTypeId };
            var deptDuplicate = await _unitofWork.ConstructionType.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Construction Type Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.ConstructionType.GetById(request.ConstructionTypeId);
            if (dept != null && dept.ConstructionTypeId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ConstructionTypeName = request.ConstructionTypeName;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.ConstructionType.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
