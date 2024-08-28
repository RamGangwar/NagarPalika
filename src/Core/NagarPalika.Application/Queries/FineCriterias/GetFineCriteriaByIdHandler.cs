using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.FineCriterias
{
    public class GetFineCriteriaByIdHandler : IRequestHandler<GetFineCriteriaByIdQuery, ResponseModel<FineCriteriaVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetFineCriteriaByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetFineCriteriaByIdHandler(IUnitofWork unitofWork, ILogger<GetFineCriteriaByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<FineCriteriaVM>> Handle(GetFineCriteriaByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.FineCriteria.GetById(request.FineCriteriaId)).Adapt<FineCriteriaVM>();
            return new ResponseModel<FineCriteriaVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

