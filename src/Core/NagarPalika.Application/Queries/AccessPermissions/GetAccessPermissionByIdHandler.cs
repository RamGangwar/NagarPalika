using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.AccessPermissions
{
    public class GetAccessPermissionByIdHandler : IRequestHandler<GetAccessPermissionByIdQuery, ResponseModel<AccessPermissionVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAccessPermissionByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetAccessPermissionByIdHandler(IUnitofWork unitofWork, ILogger<GetAccessPermissionByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<AccessPermissionVM>> Handle(GetAccessPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var depts = (await _unitofWork.AccessPermissions.GetById(request.AccessPermissionId)).Adapt<AccessPermissionVM>();
//            return new ResponseModel<AccessPermissionVM> 
//            { 
//              Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found":"No Record Found" 
//           };
            throw new NotImplementedException();
        }
    }
}

