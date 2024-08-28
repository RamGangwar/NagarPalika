using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Propertys
{
    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, ResponseModel<PropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPropertyByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetPropertyByIdHandler(IUnitofWork unitofWork, ILogger<GetPropertyByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<PropertyVM>> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var depts = (await _unitofWork.Propertys.GetById(request.PropertyId)).Adapt<PropertyVM>();
//            return new ResponseModel<PropertyVM> 
//            { 
//              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
//           };
            throw new NotImplementedException();
        }
    }
}

