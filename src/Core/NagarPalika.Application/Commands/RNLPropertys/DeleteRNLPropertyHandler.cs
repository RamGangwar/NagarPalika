using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.RNLPropertys
{
    public class DeleteRNLPropertyHandler : IRequestHandler<DeleteRNLPropertyCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteRNLPropertyHandler> _logger;

        public DeleteRNLPropertyHandler(IUnitofWork unitofWork, ILogger<DeleteRNLPropertyHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteRNLPropertyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.RNLPropertys.GetById(request.RNLPropertyId);
//            if (dept != null && dept.RNLPropertyId > 0)
//            {
//                var res = await _unitofWork.RNLPropertys.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "RNLProperty Not Found", Succeeded=false };
        }
    }
}

