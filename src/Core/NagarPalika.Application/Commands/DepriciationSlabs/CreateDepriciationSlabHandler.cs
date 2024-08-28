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
    public class CreateDepriciationSlabHandler : IRequestHandler<CreateDepriciationSlabCommand, ResponseModel<DepriciationSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDepriciationSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateDepriciationSlabHandler(IUnitofWork unitofWork, ILogger<CreateDepriciationSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DepriciationSlabVM>> Handle(CreateDepriciationSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DepriciationSlabVM>();
            var query = new { PropertyType = request.PropertyType, StartValue = request.StartValue, EndValue = request.EndValue };
            var dept = await _unitofWork.DepriciationSlab.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<DepriciationSlab>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn=DateTime.Now;
                var result = await _unitofWork.DepriciationSlab.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.DepriciationSlab.GetById(result);
                    response.Data = res.Adapt<DepriciationSlabVM>();
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
                response.Message = "Depriciation Slab Already Exists.";
                return response;
            }
        }
    }
}
