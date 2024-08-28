using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Propertys
{
    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, ResponseModel<PropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreatePropertyHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreatePropertyHandler(IUnitofWork unitofWork, ILogger<CreatePropertyHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<PropertyVM>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<PropertyVM>();
//            var query = new {PropertyName = request.PropertyName };
//            var dept = await _unitofWork.Propertys.GetByClause(query);
//            if (dept == null)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                var model = request.Adapt<Property>();
//                model.CreatedBy = Convert.ToInt32(empId);
//                model.CreatedOn = DateTime.Now;
//                var result = await _unitofWork.Propertys.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.Propertys.GetById(result);
//                    response.Data = res.Adapt<PropertyVM>();
//                    response.Succeeded=true;
//                    response.Message = "Saved Successfully.";
//                    return response;
//                }
//                else
//                {
//                    response.Succeeded=false;
//                    response.Message = "Failed to save.";
//                    return response;
//                }
//            }
//            else
//            {
//                response.Succeeded=false;
//                response.Message = Property Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

