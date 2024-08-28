using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.UserTypes
{
    public class GetUserTypeByIdHandler : IRequestHandler<GetUserTypeByIdQuery, ResponseModel<UserTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetUserTypeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetUserTypeByIdHandler(IUnitofWork unitofWork, ILogger<GetUserTypeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<UserTypeVM>> Handle(GetUserTypeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var depts = (await _unitofWork.UserTypes.GetById(request.UserTypeId)).Adapt<UserTypeVM>();
//            return new ResponseModel<UserTypeVM> 
//            { 
//              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
//           };
            throw new NotImplementedException();
        }
    }
}

