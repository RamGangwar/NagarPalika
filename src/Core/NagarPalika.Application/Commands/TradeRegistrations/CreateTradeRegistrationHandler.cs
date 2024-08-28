using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeRegistrations
{
    public class CreateTradeRegistrationHandler : IRequestHandler<CreateTradeRegistrationCommand, ResponseModel<TradeRegistrationVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateTradeRegistrationHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTradeRegistrationHandler(IUnitofWork unitofWork, ILogger<CreateTradeRegistrationHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TradeRegistrationVM>> Handle(CreateTradeRegistrationCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<TradeRegistrationVM>();
            var query = new { TradeName = request.TradeName };
            var dept = await _unitofWork.TradeRegistration.GetByClause(query);
            if (dept == null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<TradeRegistration>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.TradeRegistration.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.TradeRegistration.GetById(result);
                    response.Data = res.Adapt<TradeRegistrationVM>();
                    response.Succeeded = true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded = false;
                response.Message = "TradeRegistration Already Exists.";
                return response;
            }
        }
    }
}

