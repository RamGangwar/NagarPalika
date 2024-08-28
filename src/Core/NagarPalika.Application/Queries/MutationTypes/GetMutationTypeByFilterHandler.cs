using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MutationTypes
{
    public class GetMutationTypeByFilterHandler : IRequestHandler<GetMutationTypeByFilterQuery, PagingModel<MutationTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetMutationTypeByFilterHandler> _logger;

        public GetMutationTypeByFilterHandler(IUnitofWork unitofWork, ILogger<GetMutationTypeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<MutationTypeVM>> Handle(GetMutationTypeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.MutationType.GetByPaging(request);
            return new PagingModel<MutationTypeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

