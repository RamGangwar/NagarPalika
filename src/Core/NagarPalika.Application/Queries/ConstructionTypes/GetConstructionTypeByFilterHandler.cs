using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.ConstructionTypes
{
    public class GetConstructionTypeByFilterHandler : IRequestHandler<GetConstructionTypeByFilterQuery, PagingModel<ConstructionTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetConstructionTypeByFilterHandler> _logger;

        public GetConstructionTypeByFilterHandler(IUnitofWork unitofWork, ILogger<GetConstructionTypeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<ConstructionTypeVM>> Handle(GetConstructionTypeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.ConstructionType.GetByPaging(request);
            return new PagingModel<ConstructionTypeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

