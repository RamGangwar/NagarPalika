using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.SessionMasters
{
    public class GetSessionMasterByFilterHandler : IRequestHandler<GetSessionMasterByFilterQuery, PagingModel<SessionMasterVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetSessionMasterByFilterHandler> _logger;

        public GetSessionMasterByFilterHandler(IUnitofWork unitofWork, ILogger<GetSessionMasterByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<SessionMasterVM>> Handle(GetSessionMasterByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var result = await _unitofWork.SessionMasters.GetByPaging(request);//           return new PagingModel<SessionMasterVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

