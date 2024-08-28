using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.Queries.AccessPermissions;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AccessPermissions
{
    public class CreateAccessPermissionHandler : IRequestHandler<CreateAccessPermissionCommand, ResponseModel<AccessPermissionVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateAccessPermissionHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAccessPermissionHandler(IUnitofWork unitofWork, ILogger<CreateAccessPermissionHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<AccessPermissionVM>> Handle(CreateAccessPermissionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel<AccessPermissionVM>();

            try
            {
                _logger.LogInformation(nameof(Handle), request);
                var record = await _unitofWork.Permissions.GetByPaging(new GetAccessPermissionByFilterQuery { RoleId = request.RoleId });
                var dept = await _unitofWork.Permissions.DeleteByRole(request.RoleId);
                if (record.Count() == 0 || dept.Succeeded)
                {
                    var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                    foreach (var item in request.PermissionDatas)
                    {
                        var model = item.Adapt<AccessPermission>();
                        model.CreatedBy = Convert.ToInt32(empId);
                        model.CreatedOn = DateTime.Now;
                        model.RoleId = request.RoleId;
                        var result = await _unitofWork.Permissions.Add(model);

                    }
                    response.Succeeded = true;
                    response.Message = "Permission Assigned Successfully";
                    return response;

                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Error, Please Try again later.";
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.ToString();
                return response;
            }
        }
    }
}

