using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Propertys
{
    public class GetPropertyByFilterHandler : IRequestHandler<GetPropertyByFilterQuery, PagingModel<PropertyVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPropertyByFilterHandler> _logger;

        public GetPropertyByFilterHandler(IUnitofWork unitofWork, ILogger<GetPropertyByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<PropertyVM>> Handle(GetPropertyByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var result = await _unitofWork.Propertys.GetByPaging(request);//           return new PagingModel<PropertyVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

