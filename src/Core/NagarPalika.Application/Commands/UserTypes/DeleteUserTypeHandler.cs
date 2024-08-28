using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.UserTypes
{
    public class DeleteUserTypeHandler : IRequestHandler<DeleteUserTypeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteUserTypeHandler> _logger;

        public DeleteUserTypeHandler(IUnitofWork unitofWork, ILogger<DeleteUserTypeHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteUserTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.UserTypes.GetById(request.UserTypeId);
//            if (dept != null && dept.UserTypeId > 0)
//            {
//                var res = await _unitofWork.UserTypes.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "UserType Not Found", Succeeded=false };
        }
    }
}

