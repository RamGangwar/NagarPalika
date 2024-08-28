using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.RecieptBookss
{
    public class DeleteRecieptBooksHandler : IRequestHandler<DeleteRecieptBooksCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteRecieptBooksHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteRecieptBooksHandler(IUnitofWork unitofWork, ILogger<DeleteRecieptBooksHandler> logger, IMediator mediator)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteRecieptBooksCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.RecieptBooks.GetById(request.RecieptBookId);
            if (dept != null && dept.RecieptBookId > 0)
            {
                var res = await _unitofWork.RecieptBooks.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "RecieptBook Not Found", Succeeded=false };
        }
}
}
