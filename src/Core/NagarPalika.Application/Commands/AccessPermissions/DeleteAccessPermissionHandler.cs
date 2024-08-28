using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.AccessPermissions
{
    public class DeleteAccessPermissionHandler : IRequestHandler<DeleteAccessPermissionCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteAccessPermissionHandler> _logger;

        public DeleteAccessPermissionHandler(IUnitofWork unitofWork, ILogger<DeleteAccessPermissionHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteAccessPermissionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Permissions.DeleteByRole(request.RoleId);
            return dept;
        }
    }
}

