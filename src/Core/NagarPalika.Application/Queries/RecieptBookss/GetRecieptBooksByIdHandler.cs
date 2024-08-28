using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.RecieptBookss
{
    public class GetRecieptBooksByIdHandler : IRequestHandler<GetRecieptBooksByIdQuery, ResponseModel<RecieptBooksVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<GetRecieptBooksByIdHandler> _logger;
        private readonly IMediator _mediator;

        public GetRecieptBooksByIdHandler(IUnitofWork unitofWork, ILogger<GetRecieptBooksByIdHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel<RecieptBooksVM>> Handle(GetRecieptBooksByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);

            var depts = (await _unitofWork.RecieptBooks.GetById(request.RecieptBookId)).Adapt<RecieptBooksVM>();
            return new ResponseModel<RecieptBooksVM> { Data = depts, Succeeded = depts != null ? true : false, Message = depts != null ? "Record Found" : "No Record Found" };
        }
    }
}

