using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLAllotments
{
    public class GetRNLAllotmentByFilterHandler : IRequestHandler<GetRNLAllotmentByFilterQuery, PagingModel<RNLAllotmentVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLAllotmentByFilterHandler> _logger;

        public GetRNLAllotmentByFilterHandler(IUnitofWork unitofWork, ILogger<GetRNLAllotmentByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<RNLAllotmentVM>> Handle(GetRNLAllotmentByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.RNLAllotments.GetByPaging(request);           return new PagingModel<RNLAllotmentVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

