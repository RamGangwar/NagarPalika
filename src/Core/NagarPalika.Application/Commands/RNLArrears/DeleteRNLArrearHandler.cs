using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.RNLArrears
{
    public class DeleteRNLArrearHandler : IRequestHandler<DeleteRNLArrearCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteRNLArrearHandler> _logger;

        public DeleteRNLArrearHandler(IUnitofWork unitofWork, ILogger<DeleteRNLArrearHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteRNLArrearCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.RNLArrears.GetById(request.RNLArrearId);
//            if (dept != null && dept.RNLArrearId > 0)
//            {
//                var res = await _unitofWork.RNLArrears.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "RNLArrear Not Found", Succeeded=false };
        }
    }
}

