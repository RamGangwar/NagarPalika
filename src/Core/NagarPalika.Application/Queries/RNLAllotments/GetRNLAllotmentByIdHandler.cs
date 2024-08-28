using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.RNLAllotments
{
    public class GetRNLAllotmentByIdHandler : IRequestHandler<GetRNLAllotmentByIdQuery, ResponseModel<RNLAllotmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLAllotmentByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetRNLAllotmentByIdHandler(IUnitofWork unitofWork, ILogger<GetRNLAllotmentByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLAllotmentVM>> Handle(GetRNLAllotmentByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.RNLAllotments.GetById(request.RNLAllotmentId)).Adapt<RNLAllotmentVM>();
            return new ResponseModel<RNLAllotmentVM> 
            { 
              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
           };
            throw new NotImplementedException();
        }
    }
}

