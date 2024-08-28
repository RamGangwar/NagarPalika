using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.RecieptBookss
{
    public class CreateRecieptBooksHandler : IRequestHandler<CreateRecieptBooksCommand, ResponseModel<RecieptBooksVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CreateRecieptBooksHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateRecieptBooksHandler(IUnitofWork unitofWork, ILogger<CreateRecieptBooksHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<RecieptBooksVM>> Handle(CreateRecieptBooksCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var response = new ResponseModel<RecieptBooksVM>();
            var query = new { RecieptBook = request.RecieptBook, BookType = request.BookType };
            var dept = await _unitofWork.RecieptBooks.GetByClause(query);
            if (dept == null)
            {
                var model = request.Adapt<RecieptBooks>();
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.RecieptBooks.Add(model);
                if (result > 0)
                {
                    var res = await _unitofWork.RecieptBooks.GetById(result);
                    response.Data = res.Adapt<RecieptBooksVM>();
                    response.Succeeded = true;
                    response.Message = "Saved Successfully.";
                    return response;
                }
                else
                {
                    response.Succeeded = false;
                    response.Message = "Failed to save.";
                    return response;
                }
            }
            else
            {
                response.Succeeded = false;
                response.Message = "RecieptBook Name Already Exists.";
                return response;
            }
        }
    }
}
