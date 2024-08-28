using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DisabilitySlabs
{
    public class CreateDisabilitySlabHandler : IRequestHandler<CreateDisabilitySlabCommand, ResponseModel<DisabilitySlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDisabilitySlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateDisabilitySlabHandler(IUnitofWork unitofWork, ILogger<CreateDisabilitySlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DisabilitySlabVM>> Handle(CreateDisabilitySlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DisabilitySlabVM>();
            var query = new { PropertyType = request.PropertyType, StartValue = request.StartValue, EndValue = request.EndValue };
            var dept = await _unitofWork.DisabilitySlab.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<DisabilitySlab>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.DisabilitySlab.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.DisabilitySlab.GetById(result);
                    response.Data = res.Adapt<DisabilitySlabVM>();
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
                response.Message = "Disability Slab Already Exists.";
                return response;
            }
        }
}
}
