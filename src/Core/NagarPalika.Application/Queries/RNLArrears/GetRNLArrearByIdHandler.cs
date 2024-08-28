using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.RNLArrears
{
    public class GetRNLArrearByIdHandler : IRequestHandler<GetRNLArrearByIdQuery, ResponseModel<RNLArrearVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLArrearByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetRNLArrearByIdHandler(IUnitofWork unitofWork, ILogger<GetRNLArrearByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RNLArrearVM>> Handle(GetRNLArrearByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var depts = (await _unitofWork.RNLArrears.GetById(request.RNLArrearId)).Adapt<RNLArrearVM>();
            return new ResponseModel<RNLArrearVM> 
            { 
              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
           };
            throw new NotImplementedException();
        }
    }
}

