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
    public class UpdateRecieptBooksHandler : IRequestHandler<UpdateRecieptBooksCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateRecieptBooksHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateRecieptBooksHandler(IUnitofWork unitofWork, ILogger<UpdateRecieptBooksHandler> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Handle(UpdateRecieptBooksCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { RecieptBook = request.RecieptBook, BookType = request.BookType, RecieptBookId_neq = request.RecieptBookId };
            var deptDuplicate = await _unitofWork.RecieptBooks.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "RecieptBook Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.RecieptBooks.GetById(request.RecieptBookId);
            if (dept != null && dept.RecieptBookId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                dept.RecieptBook = request.RecieptBook;
                dept.StartSrNo = request.StartSrNo;
                dept.EndSrNo = request.EndSrNo;
                dept.AllowcatedTo = request.AllowcatedTo;
                dept.BookType = request.BookType;
                var result = await _unitofWork.RecieptBooks.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}
