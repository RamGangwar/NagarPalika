using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.RoadWidthTypes
{
    public class UpdateRoadWidthTypeHandler : IRequestHandler<UpdateRoadWidthTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateRoadWidthTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateRoadWidthTypeHandler(IUnitofWork unitofWork, ILogger<UpdateRoadWidthTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateRoadWidthTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { RoadWidthTypeName = request.RoadWidthTypeName, RoadWidthTypeId_neq = request.RoadWidthTypeId };
            var deptDuplicate = await _unitofWork.RoadWidthType.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Road Width Type Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.RoadWidthType.GetById(request.RoadWidthTypeId);
            if (dept != null && dept.RoadWidthTypeId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.RoadWidthTypeName = request.RoadWidthTypeName;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.RoadWidthType.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
