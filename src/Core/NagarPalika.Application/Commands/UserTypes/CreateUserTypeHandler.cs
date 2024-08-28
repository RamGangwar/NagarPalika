using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.UserTypes
{
    public class CreateUserTypeHandler : IRequestHandler<CreateUserTypeCommand, ResponseModel<UserTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateUserTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateUserTypeHandler(IUnitofWork unitofWork, ILogger<CreateUserTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<UserTypeVM>> Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<UserTypeVM>();
//            var query = new {UserTypeName = request.UserTypeName };
//            var dept = await _unitofWork.UserTypes.GetByClause(query);
//            if (dept == null)
//            {
//                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
//                var model = request.Adapt<UserType>();
//                model.CreatedBy = Convert.ToInt32(empId);
//                model.CreatedOn = DateTime.Now;
//                var result = await _unitofWork.UserTypes.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.UserTypes.GetById(result);
//                    response.Data = res.Adapt<UserTypeVM>();
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
//                response.Message = UserType Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

