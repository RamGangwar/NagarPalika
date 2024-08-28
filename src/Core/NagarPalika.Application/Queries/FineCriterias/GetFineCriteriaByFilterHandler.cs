using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.FineCriterias
{
    public class GetFineCriteriaByFilterHandler : IRequestHandler<GetFineCriteriaByFilterQuery, PagingModel<FineCriteriaVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetFineCriteriaByFilterHandler> _logger;

        public GetFineCriteriaByFilterHandler(IUnitofWork unitofWork, ILogger<GetFineCriteriaByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<FineCriteriaVM>> Handle(GetFineCriteriaByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.FineCriteria.GetByPaging(request);
            return new PagingModel<FineCriteriaVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

