using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PropertyTypes
{
    public class GetPropertyTypeByFilterHandler : IRequestHandler<GetPropertyTypeByFilterQuery, PagingModel<PropertyTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPropertyTypeByFilterHandler> _logger;

        public GetPropertyTypeByFilterHandler(IUnitofWork unitofWork, ILogger<GetPropertyTypeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<PropertyTypeVM>> Handle(GetPropertyTypeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.PropertyType.GetByPaging(request);
            return new PagingModel<PropertyTypeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

