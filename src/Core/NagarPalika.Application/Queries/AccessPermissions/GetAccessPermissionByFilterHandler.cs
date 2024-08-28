using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AccessPermissions
{
    public class GetAccessPermissionByFilterHandler : IRequestHandler<GetAccessPermissionByFilterQuery, List<AccessPermissionVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetAccessPermissionByFilterHandler> _logger;

        public GetAccessPermissionByFilterHandler(IUnitofWork unitofWork, ILogger<GetAccessPermissionByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<List<AccessPermissionVM>> Handle(GetAccessPermissionByFilterQuery request, CancellationToken cancellationToken)
        
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.Permissions.GetByPaging(request);
            var resList = result.ToList();
            
            return resList;
        }
    }
}

