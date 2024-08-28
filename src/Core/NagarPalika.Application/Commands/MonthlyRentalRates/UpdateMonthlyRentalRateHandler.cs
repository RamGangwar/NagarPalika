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
    public class UpdateMonthlyRentalRateHandler : IRequestHandler<UpdateMonthlyRentalRateCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateMonthlyRentalRateHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateMonthlyRentalRateHandler(IUnitofWork unitofWork, ILogger<UpdateMonthlyRentalRateHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateMonthlyRentalRateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { WardId = request.WardId, LocalityId = request.LocalityId, ConstructionTypeId = request.ConstructionTypeId, RaodWidthTypeId = request.RaodWidthTypeId, MonthlyRentalRateId_neq = request.MonthlyRentalRateId };
            var deptDuplicate = await _unitofWork.MonthlyRentalRate.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Monthly Rental Rate Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.MonthlyRentalRate.GetById(request.MonthlyRentalRateId);
            if (dept != null && dept.MonthlyRentalRateId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.WardId = request.WardId;
                dept.LocalityId = request.LocalityId;
                dept.RaodWidthTypeId = request.RaodWidthTypeId;
                dept.ConstructionTypeId = request.ConstructionTypeId;
                dept.ConstructedAreaRate = request.ConstructedAreaRate;
                dept.EmptyAreaRate = request.EmptyAreaRate;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.MonthlyRentalRate.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}
