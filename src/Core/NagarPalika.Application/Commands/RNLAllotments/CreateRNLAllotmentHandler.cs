using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLAllotments
{
    public class CreateRNLAllotmentHandler : IRequestHandler<CreateRNLAllotmentCommand, ResponseModel<RNLAllotmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRNLAllotmentHandler> _logger;
        private readonly IMediator _mediator;

        public CreateRNLAllotmentHandler(IUnitofWork unitofWork, ILogger<CreateRNLAllotmentHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLAllotmentVM>> Handle(CreateRNLAllotmentCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RNLAllotmentVM>();
//            var query = new {RNLAllotmentName = request.RNLAllotmentName };
//            var dept = await _unitofWork.RNLAllotments.GetByClause(query);
//            if (dept==null)
//            {
//                var model = request.Adapt<RNLAllotment>();
//                var result = await _unitofWork.RNLAllotments.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.RNLAllotments.GetById(result);
//                    response.Data = res.Adapt<RNLAllotmentVM>();
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
//                response.Message = RNLAllotment Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

