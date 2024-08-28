using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.RNLAllotments
{
    public class UpdateRNLAllotmentHandler : IRequestHandler<UpdateRNLAllotmentCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateRNLAllotmentHandler> _logger;
        public UpdateRNLAllotmentHandler(IUnitofWork unitofWork, ILogger<UpdateRNLAllotmentHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }
        public async Task<ResponseModel> Handle(UpdateRNLAllotmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {RNLAllotmentName = request.RNLAllotmentName, RNLAllotmentId_neq = request.RNLAllotmentId };
//            var deptDuplicate = await _unitofWork.RNLAllotments.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "RNLAllotment Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.RNLAllotments.GetById(request.RNLAllotmentId);
//            if (dept != null && dept.RNLAllotmentId > 0)
//            {
//                dept.RNLAllotmentName = request.RNLAllotmentName;
//                dept.IsActive = request.IsActive;
//                var result = await _unitofWork.RNLAllotments.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

