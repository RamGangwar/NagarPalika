using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeCategorys
{
    public class CreateTradeCategoryHandler : IRequestHandler<CreateTradeCategoryCommand, ResponseModel<TradeCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateTradeCategoryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTradeCategoryHandler(IUnitofWork unitofWork, ILogger<CreateTradeCategoryHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TradeCategoryVM>> Handle(CreateTradeCategoryCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<TradeCategoryVM>();
            var query = new {TradeCategoryName = request.TradeCategoryName };
            var dept = await _unitofWork.TradeCategory.GetByClause(query);
            if (dept == null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<TradeCategory>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.TradeCategory.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.TradeCategory.GetById(result);
                    response.Data = res.Adapt<TradeCategoryVM>();
                    response.Succeeded=true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded=false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded=false;
                response.Message = "TradeCategory Already Exists.";
                return response;
            }
        }
    }
}

