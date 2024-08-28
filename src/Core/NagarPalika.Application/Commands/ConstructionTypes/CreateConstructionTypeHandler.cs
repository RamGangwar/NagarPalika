using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.ConstructionTypes
{
    public class CreateConstructionTypeHandler : IRequestHandler<CreateConstructionTypeCommand, ResponseModel<ConstructionTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateConstructionTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateConstructionTypeHandler(IUnitofWork unitofWork, ILogger<CreateConstructionTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<ConstructionTypeVM>> Handle(CreateConstructionTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<ConstructionTypeVM>();
            var query = new { ConstructionTypeName = request.ConstructionTypeName };
            var dept = await _unitofWork.ConstructionType.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<ConstructionType>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.ConstructionType.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.ConstructionType.GetById(result);
                    response.Data = res.Adapt<ConstructionTypeVM>();
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
                response.Message = "Construction Type Already Exists.";
                return response;
            }
        }
}
}
