using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.Localitys
{
    public class CreateLocalityHandler : IRequestHandler<CreateLocalityCommand, ResponseModel<LocalityVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateLocalityHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateLocalityHandler(IUnitofWork unitofWork, ILogger<CreateLocalityHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<LocalityVM>> Handle(CreateLocalityCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<LocalityVM>();
            var dept = await _unitofWork.Locality.GetByClause(new { LocalityName = request.LocalityName });
            if (dept==null)
            {
                var model = request.Adapt<Locality>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Locality.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.Locality.GetById(result);
                    response.Data = res.Adapt<LocalityVM>();
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
                response.Message = "Locality Already Exists.";
                return response;
            }
        }
    }
}
