using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeSubCategorys
{
    public class CreateTradeSubCategoryHandler : IRequestHandler<CreateTradeSubCategoryCommand, ResponseModel<TradeSubCategoryVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateTradeSubCategoryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTradeSubCategoryHandler(IUnitofWork unitofWork, ILogger<CreateTradeSubCategoryHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TradeSubCategoryVM>> Handle(CreateTradeSubCategoryCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<TradeSubCategoryVM>();
            var query = new { TradeSubCategoryName = request.TradeSubCategoryName };
            var dept = await _unitofWork.TradeSubCategory.GetByClause(query);
            if (dept == null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<TradeSubCategory>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.TradeSubCategory.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.TradeSubCategory.GetById(result);
                    response.Data = res.Adapt<TradeSubCategoryVM>();
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
                response.Message = "TradeSubCategory Already Exists.";
                return response;
            }
        }
    }
}

