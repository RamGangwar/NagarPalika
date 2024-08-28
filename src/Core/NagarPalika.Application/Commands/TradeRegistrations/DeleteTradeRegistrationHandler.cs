using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.TradeRegistrations
{
    public class DeleteTradeRegistrationHandler : IRequestHandler<DeleteTradeRegistrationCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteTradeRegistrationHandler> _logger;

        public DeleteTradeRegistrationHandler(IUnitofWork unitofWork, ILogger<DeleteTradeRegistrationHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteTradeRegistrationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.TradeRegistration.GetById(request.TradeRegistrationId);
            if (dept != null && dept.TradeRegistrationId > 0)
            {
                var res = await _unitofWork.TradeRegistration.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "TradeRegistration Not Found", Succeeded = false };
        }
    }
}

