using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Propertys
{
    public class DeletePropertyHandler : IRequestHandler<DeletePropertyCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeletePropertyHandler> _logger;

        public DeletePropertyHandler(IUnitofWork unitofWork, ILogger<DeletePropertyHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.Propertys.GetById(request.PropertyId);
//            if (dept != null && dept.PropertyId > 0)
//            {
//                var res = await _unitofWork.Propertys.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "Property Not Found", Succeeded=false };
        }
    }
}

