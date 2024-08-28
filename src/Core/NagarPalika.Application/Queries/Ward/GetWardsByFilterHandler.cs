using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Ward
{
    public class GetWardsByFilterHandler : IRequestHandler<GetWardsByFilterQuery, PagingModel<WardsVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetWardsByFilterHandler> _logger;

        public GetWardsByFilterHandler(IUnitofWork unitofWork, ILogger<GetWardsByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<WardsVM>> Handle(GetWardsByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Wards.GetByPaging(request);
            return new PagingModel<WardsVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}
