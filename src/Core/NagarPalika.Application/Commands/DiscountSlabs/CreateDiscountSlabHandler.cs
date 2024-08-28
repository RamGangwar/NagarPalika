using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.DiscountSlabs
{
    public class CreateDiscountSlabHandler : IRequestHandler<CreateDiscountSlabCommand, ResponseModel<DiscountSlabVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateDiscountSlabHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateDiscountSlabHandler(IUnitofWork unitofWork, ILogger<CreateDiscountSlabHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<DiscountSlabVM>> Handle(CreateDiscountSlabCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<DiscountSlabVM>();
            var query = new { PropertyType = request.PropertyType, StartDate = request.StartDate, EndDate = request.EndDate };
            var dept = await _unitofWork.DiscountSlab.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<DiscountSlab>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.DiscountSlab.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.DiscountSlab.GetById(result);
                    response.Data = res.Adapt<DiscountSlabVM>();
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
                response.Message = "Discount Slab Already Exists.";
                return response;
            }
        }
}
}
