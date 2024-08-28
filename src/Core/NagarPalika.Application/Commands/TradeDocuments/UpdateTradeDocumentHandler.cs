using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.TradeDocuments
{
    public class UpdateTradeDocumentHandler : IRequestHandler<UpdateTradeDocumentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateTradeDocumentHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateTradeDocumentHandler(IUnitofWork unitofWork, ILogger<UpdateTradeDocumentHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel> Handle(UpdateTradeDocumentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var query = new { TradeDocumentName = request.TradeDocumentName, TradeDocumentId_neq = request.TradeDocumentId };
            var deptDuplicate = await _unitofWork.TradeDocuments.GetByClause(query);
            if (deptDuplicate != null)
            {
                return new ResponseModel { Message = "Trade Document Already Exists", Succeeded = false };
            }
            var dept = await _unitofWork.TradeDocuments.GetById(request.TradeDocumentId);
            if (dept != null && dept.TradeDocumentId > 0)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                dept.TradeDocumentName = request.TradeDocumentName;
                dept.ModifyBy = Convert.ToInt32(empId);
                dept.ModifyOn = DateTime.Now;
                var result = await _unitofWork.TradeDocuments.Update(dept);
                if (result)
                {
                    return new ResponseModel { Message = "Updated Successfully", Succeeded = true };
                }
            }
            return new ResponseModel { Message = "Failed to update", Succeeded = false };
        }
    }
}

