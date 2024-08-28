using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PosessonModes
{
    public class GetPosessonModeByFilterHandler : IRequestHandler<GetPosessonModeByFilterQuery, PagingModel<PosessonModeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetPosessonModeByFilterHandler> _logger;

        public GetPosessonModeByFilterHandler(IUnitofWork unitofWork, ILogger<GetPosessonModeByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<PosessonModeVM>> Handle(GetPosessonModeByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.PosessonModes.GetByPaging(request);           return new PagingModel<PosessonModeVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
            throw new NotImplementedException();
        }
    }
}

