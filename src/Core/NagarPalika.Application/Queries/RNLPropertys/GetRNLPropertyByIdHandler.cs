using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.RNLPropertys
{
    public class GetRNLPropertyByIdHandler : IRequestHandler<GetRNLPropertyByIdQuery, ResponseModel<RNLPropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLPropertyByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetRNLPropertyByIdHandler(IUnitofWork unitofWork, ILogger<GetRNLPropertyByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLPropertyVM>> Handle(GetRNLPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.RNLPropertys.GetById(request.RNLPropertyId)).Adapt<RNLPropertyVM>();
            return new ResponseModel<RNLPropertyVM> 
            { 
              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
           };
            throw new NotImplementedException();
        }
    }
}

