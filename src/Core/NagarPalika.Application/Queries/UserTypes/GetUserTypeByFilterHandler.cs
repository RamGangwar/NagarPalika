using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.UserTypes
{
    public class GetUserTypeByFilterHandler : IRequestHandler<GetUserTypeByFilterQuery, PagingModel<UserTypeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetUserTypeByFilterHandler> _logger;

        public GetUserTypeByFilterHandler(IUnitofWork unitofWork, ILogger<GetUserTypeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<UserTypeVM>> Handle(GetUserTypeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var result = await _unitofWork.UserTypes.GetByPaging(request);//           return new PagingModel<UserTypeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

