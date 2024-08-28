using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.PosessonModes
{
    public class CreatePosessonModeHandler : IRequestHandler<CreatePosessonModeCommand, ResponseModel<PosessonModeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreatePosessonModeHandler> _logger;
        private readonly IMediator _mediator;

        public CreatePosessonModeHandler(IUnitofWork unitofWork, ILogger<CreatePosessonModeHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<PosessonModeVM>> Handle(CreatePosessonModeCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<PosessonModeVM>();
//            var query = new {PosessonModeName = request.PosessonModeName };
//            var dept = await _unitofWork.PosessonModes.GetByClause(query);
//            if (dept==null)
//            {
//                var model = request.Adapt<PosessonMode>();
//                var result = await _unitofWork.PosessonModes.Add(model);
//                if (result > 0)
//                {
//                    var res = await _unitofWork.PosessonModes.GetById(result);
//                    response.Data = res.Adapt<PosessonModeVM>();
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
//                response.Message = PosessonMode Already Exists.";
//                return response;
//            }
             return response;
        }
    }
}

