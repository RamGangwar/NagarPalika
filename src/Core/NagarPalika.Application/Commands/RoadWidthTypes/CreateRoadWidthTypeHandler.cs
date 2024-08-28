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
    public class CreateRoadWidthTypeHandler : IRequestHandler<CreateRoadWidthTypeCommand, ResponseModel<RoadWidthTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRoadWidthTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRoadWidthTypeHandler(IUnitofWork unitofWork, ILogger<CreateRoadWidthTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<RoadWidthTypeVM>> Handle(CreateRoadWidthTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RoadWidthTypeVM>();
            var query = new { RoadWidthTypeName = request.RoadWidthTypeName };
            var dept = await _unitofWork.RoadWidthType.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<RoadWidthType>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.RoadWidthType.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.RoadWidthType.GetById(result);
                    response.Data = res.Adapt<RoadWidthTypeVM>();
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
                response.Message = "Road Width Type Already Exists.";
                return response;
            }
        }
}
}
