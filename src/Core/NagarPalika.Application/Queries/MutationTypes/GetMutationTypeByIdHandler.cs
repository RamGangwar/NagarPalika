using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.MutationTypes
{
    public class GetMutationTypeByIdHandler : IRequestHandler<GetMutationTypeByIdQuery, ResponseModel<MutationTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetMutationTypeByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetMutationTypeByIdHandler(IUnitofWork unitofWork, ILogger<GetMutationTypeByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<MutationTypeVM>> Handle(GetMutationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.MutationType.GetById(request.MutationTypeId)).Adapt<MutationTypeVM>();
            return new ResponseModel<MutationTypeVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

