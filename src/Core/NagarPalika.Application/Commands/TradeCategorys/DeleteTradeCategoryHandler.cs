using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.TradeCategorys
{
    public class DeleteTradeCategoryHandler : IRequestHandler<DeleteTradeCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTradeCategoryHandler> _logger;

        public DeleteTradeCategoryHandler(IUnitofWork unitofWork, ILogger<DeleteTradeCategoryHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteTradeCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.TradeCategory.GetById(request.TradeCategoryId);
            if (dept != null && dept.TradeCategoryId > 0)
            {
                var res = await _unitofWork.TradeCategory.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "TradeCategory Not Found", Succeeded=false };
        }
    }
}

