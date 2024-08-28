using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLPropertys
{
    public class GetRNLPropertyByFilterHandler : IRequestHandler<GetRNLPropertyByFilterQuery, PagingModel<RNLPropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRNLPropertyByFilterHandler> _logger;

        public GetRNLPropertyByFilterHandler(IUnitofWork unitofWork, ILogger<GetRNLPropertyByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<RNLPropertyVM>> Handle(GetRNLPropertyByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.RNLPropertys.GetByPaging(request);          
            return new PagingModel<RNLPropertyVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

