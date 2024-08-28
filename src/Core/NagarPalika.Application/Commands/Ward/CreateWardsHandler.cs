using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.Ward
{
    public class CreateWardsHandler : IRequestHandler<CreateWardsCommand, ResponseModel<WardsVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateWardsHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateWardsHandler(IUnitofWork unitofWork, ILogger<CreateWardsHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<WardsVM>> Handle(CreateWardsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<WardsVM>();
            var dept = await _unitofWork.Wards.GetByClause(new { WardName = request.WardName });
            if (dept==null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = request.Adapt<Wards>();
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Wards.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Wards.GetById(result);
                    response.Data = res.Adapt<WardsVM>();
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
                response.Message = "Ward Already Exists.";
                return response;
            }
        }
    }
}
