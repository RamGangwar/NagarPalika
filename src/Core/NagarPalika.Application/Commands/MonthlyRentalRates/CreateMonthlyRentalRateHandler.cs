using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.MonthlyRentalRates
{
    public class CreateMonthlyRentalRateHandler : IRequestHandler<CreateMonthlyRentalRateCommand, ResponseModel<MonthlyRentalRateVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateMonthlyRentalRateHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateMonthlyRentalRateHandler(IUnitofWork unitofWork, ILogger<CreateMonthlyRentalRateHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<MonthlyRentalRateVM>> Handle(CreateMonthlyRentalRateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<MonthlyRentalRateVM>();
            var query = new { WardId = request.WardId, LocalityId = request.LocalityId, ConstructionTypeId = request.ConstructionTypeId, RaodWidthTypeId = request.RaodWidthTypeId };
            var dept = await _unitofWork.MonthlyRentalRate.GetByClause(query);
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<MonthlyRentalRate>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.MonthlyRentalRate.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.MonthlyRentalRate.GetById(result);
                    response.Data = res.Adapt<MonthlyRentalRateVM>();
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
                response.Message = "Monthly Rental Rate Already Exists.";
                return response;
            }
        }
}
}
