using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DepriciationSlabs
{
    public class UpdateDepriciationSlabHandler : IRequestHandler<UpdateDepriciationSlabCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateDepriciationSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateDepriciationSlabHandler(IUnitofWork unitofWork, ILogger<UpdateDepriciationSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateDepriciationSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { PropertyType= request.PropertyType, StartValue = request.StartValue, EndValue = request.EndValue, DepriciationSlabId_neq = request.DepriciationSlabId };
            var deptDuplicate = await _unitofWork.DepriciationSlab.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Depriciation Slab Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.DepriciationSlab.GetById(request.DepriciationSlabId);
            if (dept != null && dept.DepriciationSlabId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.StartValue = request.StartValue;
                dept.EndValue = request.EndValue;
                dept.Value = request.Value;
                dept.PropertyType = request.PropertyType;
                var result = await _unitofWork.DepriciationSlab.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
}
}
