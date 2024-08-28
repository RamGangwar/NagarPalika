using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.MutationTypes
{
    public class UpdateMutationTypeHandler : IRequestHandler<UpdateMutationTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateMutationTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateMutationTypeHandler(IUnitofWork unitofWork, ILogger<UpdateMutationTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateMutationTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { MutationTypeName = request.MutationTypeName, MutationTypeId_neq = request.MutationTypeId };
            var deptDuplicate = await _unitofWork.MutationType.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Mutation Type Already Exists", Succeeded=false };
            }
            var dept = await _unitofWork.MutationType.GetById(request.MutationTypeId);
            if (dept != null && dept.MutationTypeId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.MutationTypeName = request.MutationTypeName;
                dept.MutationFee = request.MutationFee;
                var result = await _unitofWork.MutationType.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded=true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded=false };
        }
    }
}
