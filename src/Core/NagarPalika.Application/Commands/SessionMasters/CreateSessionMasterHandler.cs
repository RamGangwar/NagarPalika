using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.SessionMasters
{
    public class CreateSessionMasterHandler : IRequestHandler<CreateSessionMasterCommand, ResponseModel<SessionMasterVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateSessionMasterHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateSessionMasterHandler(IUnitofWork unitofWork, ILogger<CreateSessionMasterHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<SessionMasterVM>> Handle(CreateSessionMasterCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<SessionMasterVM>();
//            var query = new {SessionMasterName = request.SessionMasterName };
//            var dept = await _unitofWork.SessionMasters.GetByClause(query);
//            if (dept == null)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                var model = request.Adapt<SessionMaster>();
//                model.CreatedBy = Convert.ToInt32(empId);
//                model.CreatedOn = DateTime.Now;
//                var result = await _unitofWork.SessionMasters.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.SessionMasters.GetById(result);
//                    response.Data = res.Adapt<SessionMasterVM>();
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
//                response.Message = SessionMaster Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

