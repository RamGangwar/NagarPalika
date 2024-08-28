using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLArrears
{
    public class GetRNLArrearByFilterHandler : IRequestHandler<GetRNLArrearByFilterQuery, PagingModel<RNLArrearVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLArrearByFilterHandler> _logger;

        public GetRNLArrearByFilterHandler(IUnitofWork unitofWork, ILogger<GetRNLArrearByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<RNLArrearVM>> Handle(GetRNLArrearByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.RNLArrears.GetByPaging(request);           return new PagingModel<RNLArrearVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

