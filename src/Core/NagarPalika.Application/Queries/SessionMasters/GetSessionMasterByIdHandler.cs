using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.SessionMasters
{
    public class GetSessionMasterByIdHandler : IRequestHandler<GetSessionMasterByIdQuery, ResponseModel<SessionMasterVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetSessionMasterByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetSessionMasterByIdHandler(IUnitofWork unitofWork, ILogger<GetSessionMasterByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<SessionMasterVM>> Handle(GetSessionMasterByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var depts = (await _unitofWork.SessionMasters.GetById(request.SessionMasterId)).Adapt<SessionMasterVM>();
//            return new ResponseModel<SessionMasterVM> 
//            { 
//              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
//           };
            throw new NotImplementedException();
        }
    }
}

