using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLPropertys
{
    public class CreateRNLPropertyHandler : IRequestHandler<CreateRNLPropertyCommand, ResponseModel<RNLPropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRNLPropertyHandler> _logger;
        private readonly IMediator _mediator;

        public CreateRNLPropertyHandler(IUnitofWork unitofWork, ILogger<CreateRNLPropertyHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLPropertyVM>> Handle(CreateRNLPropertyCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RNLPropertyVM>();
//            var query = new {RNLPropertyName = request.RNLPropertyName };
//            var dept = await _unitofWork.RNLPropertys.GetByClause(query);
//            if (dept==null)
//            {
//                var model = request.Adapt<RNLProperty>();
//                var result = await _unitofWork.RNLPropertys.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.RNLPropertys.GetById(result);
//                    response.Data = res.Adapt<RNLPropertyVM>();
//                    response.Succeeded=true;
//                    response.Message = "Saved Successfully.";
//                    return response;
//                }
//                else
//                {
//                    response.Succeeded=false;
//                    response.Message = "Failed to save.";
//                    return response;
//                }
//            }
//            else
//            {
//                response.Succeeded=false;
//                response.Message = RNLProperty Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

