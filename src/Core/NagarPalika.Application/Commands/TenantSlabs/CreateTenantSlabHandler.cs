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
    public class CreateTenantSlabHandler : IRequestHandler<CreateTenantSlabCommand, ResponseModel<TenantSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateTenantSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateTenantSlabHandler(IUnitofWork unitofWork, ILogger<CreateTenantSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TenantSlabVM>> Handle(CreateTenantSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<TenantSlabVM>();
            var query = new { PropertyType = request.PropertyType };
            var dept = await _unitofWork.TenantSlab.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<TenantSlab>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.TenantSlab.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.TenantSlab.GetById(result);
                    response.Data = res.Adapt<TenantSlabVM>();
                    response.Succeeded=true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded=false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded=false;
                response.Message = "Tenant Slab Already Exists.";
                return response;
            }
        }
}
}
