using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.FineCriterias
{
    public class CreateFineCriteriaHandler : IRequestHandler<CreateFineCriteriaCommand, ResponseModel<FineCriteriaVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateFineCriteriaHandler> _logger;
        private readonly IMediator _mediator; 
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateFineCriteriaHandler(IUnitofWork unitofWork, ILogger<CreateFineCriteriaHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<FineCriteriaVM>> Handle(CreateFineCriteriaCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<FineCriteriaVM>();
            var query = new { PropertyType = request.PropertyType};
            var dept = await _unitofWork.FineCriteria.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<FineCriteria>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.FineCriteria.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.FineCriteria.GetById(result);
                    response.Data = res.Adapt<FineCriteriaVM>();
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
                response.Message = "Fine Criteria Already Exists.";
                return response;
            }
        }
}
}
