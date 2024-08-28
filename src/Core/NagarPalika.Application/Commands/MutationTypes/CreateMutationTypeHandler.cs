using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.MutationTypes
{
    public class CreateMutationTypeHandler : IRequestHandler<CreateMutationTypeCommand, ResponseModel<MutationTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateMutationTypeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateMutationTypeHandler(IUnitofWork unitofWork, ILogger<CreateMutationTypeHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<MutationTypeVM>> Handle(CreateMutationTypeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<MutationTypeVM>();
            var query = new { MutationTypeName = request.MutationTypeName };
            var dept = await _unitofWork.MutationType.GetByClause(query);
            if (dept==null)
            {
                var model = request.Adapt<MutationType>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.MutationType.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.MutationType.GetById(result);
                    response.Data = res.Adapt<MutationTypeVM>();
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
                response.Message = "Mutation Type Name Already Exists.";
                return response;
            }
        }
}
}
