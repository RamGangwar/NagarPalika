using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RoadWidthTypes
{
    public class GetRoadWidthTypeByFilterHandler : IRequestHandler<GetRoadWidthTypeByFilterQuery, PagingModel<RoadWidthTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRoadWidthTypeByFilterHandler> _logger;

        public GetRoadWidthTypeByFilterHandler(IUnitofWork unitofWork, ILogger<GetRoadWidthTypeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<RoadWidthTypeVM>> Handle(GetRoadWidthTypeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.RoadWidthType.GetByPaging(request);
            return new PagingModel<RoadWidthTypeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

