using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.TradeSubCategorys
{
    public class DeleteTradeSubCategoryHandler : IRequestHandler<DeleteTradeSubCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTradeSubCategoryHandler> _logger;

        public DeleteTradeSubCategoryHandler(IUnitofWork unitofWork, ILogger<DeleteTradeSubCategoryHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteTradeSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.TradeSubCategory.GetById(request.TradeSubCategoryId);
            if (dept != null && dept.TradeSubCategoryId > 0)
            {
                var res = await _unitofWork.TradeSubCategory.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "TradeSubCategory Not Found", Succeeded=false };
        }
    }
}

