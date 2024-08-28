using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.TradeDocuments
{
    public class DeleteTradeDocumentHandler : IRequestHandler<DeleteTradeDocumentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTradeDocumentHandler> _logger;

        public DeleteTradeDocumentHandler(IUnitofWork unitofWork, ILogger<DeleteTradeDocumentHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteTradeDocumentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var dept = await _unitofWork.TradeDocuments.GetById(request.TradeDocumentId);
//            if (dept != null && dept.TradeDocumentId > 0)
//            {
//                var res = await _unitofWork.TradeDocuments.Delete(dept);
//                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
//            }
            return new ResponseModel { Message = "TradeDocument Not Found", Succeeded=false };
        }
    }
}

