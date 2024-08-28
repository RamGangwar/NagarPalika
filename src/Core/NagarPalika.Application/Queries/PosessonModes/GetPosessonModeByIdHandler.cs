using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.PosessonModes
{
    public class GetPosessonModeByIdHandler : IRequestHandler<GetPosessonModeByIdQuery, ResponseModel<PosessonModeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPosessonModeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetPosessonModeByIdHandler(IUnitofWork unitofWork, ILogger<GetPosessonModeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<PosessonModeVM>> Handle(GetPosessonModeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.PosessonModes.GetById(request.PosessonModeId)).Adapt<PosessonModeVM>();
            return new ResponseModel<PosessonModeVM> 
            { 
              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
           };
            throw new NotImplementedException();
        }
    }
}

