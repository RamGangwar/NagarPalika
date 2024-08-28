using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Role
{
    public class GetRolesByIdHandler : IRequestHandler<GetRolesByIdQuery, ResponseModel<RolesVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRolesByIdHandler> _logger;

        public GetRolesByIdHandler(IUnitofWork unitofWork, ILogger<GetRolesByIdHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel<RolesVM>> Handle(GetRolesByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.Roles.GetById(request.RoleId)).Adapt<RolesVM>();
            return new ResponseModel<RolesVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}
