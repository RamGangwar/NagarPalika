using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RecieptBookss
{
    public class GetRecieptBooksByFilterHandler : IRequestHandler<GetRecieptBooksByFilterQuery, PagingModel<RecieptBooksVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRecieptBooksByFilterHandler> _logger;

        public GetRecieptBooksByFilterHandler(IUnitofWork unitofWork, ILogger<GetRecieptBooksByFilterHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<PagingModel<RecieptBooksVM>> Handle(GetRecieptBooksByFilterQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var result = await _unitofWork.RecieptBooks.GetByPaging(request);
            return new PagingModel<RecieptBooksVM>(result, request.PageIndex, request.PageSize, result.Count() > 0 ? result.FirstOrDefault().TotalRecord : 0);
        }
    }
}

