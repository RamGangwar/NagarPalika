using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.RNLAllotments
{
    public class DeleteRNLAllotmentHandler : IRequestHandler<DeleteRNLAllotmentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteRNLAllotmentHandler> _logger;

        public DeleteRNLAllotmentHandler(IUnitofWork unitofWork, ILogger<DeleteRNLAllotmentHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteRNLAllotmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.RNLAllotments.GetById(request.RNLAllotmentId);
//            if (dept != null && dept.RNLAllotmentId > 0)
//            {
//                var res = await _unitofWork.RNLAllotments.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "RNLAllotment Not Found", Succeeded=false };
        }
    }
}

