using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLArrears
{
    public class CreateRNLArrearHandler : IRequestHandler<CreateRNLArrearCommand, ResponseModel<RNLArrearVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRNLArrearHandler> _logger;
        private readonly IMediator _mediator;

        public CreateRNLArrearHandler(IUnitofWork unitofWork, ILogger<CreateRNLArrearHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLArrearVM>> Handle(CreateRNLArrearCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RNLArrearVM>();
//            var query = new {RNLArrearName = request.RNLArrearName };
//            var dept = await _unitofWork.RNLArrears.GetByClause(query);
//            if (dept==null)
//            {
//                var model = request.Adapt<RNLArrear>();
//                var result = await _unitofWork.RNLArrears.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.RNLArrears.GetById(result);
//                    response.Data = res.Adapt<RNLArrearVM>();
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
//                response.Message = RNLArrear Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

