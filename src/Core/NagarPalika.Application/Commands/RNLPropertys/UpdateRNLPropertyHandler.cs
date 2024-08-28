using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.RNLPropertys
{
    public class UpdateRNLPropertyHandler : IRequestHandler<UpdateRNLPropertyCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateRNLPropertyHandler> _logger;
        public UpdateRNLPropertyHandler(IUnitofWork unitofWork, ILogger<UpdateRNLPropertyHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }
        public async Task<ResponseModel> Handle(UpdateRNLPropertyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {RNLPropertyName = request.RNLPropertyName, RNLPropertyId_neq = request.RNLPropertyId };
//            var deptDuplicate = await _unitofWork.RNLPropertys.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "RNLProperty Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.RNLPropertys.GetById(request.RNLPropertyId);
//            if (dept != null && dept.RNLPropertyId > 0)
//            {
//                dept.RNLPropertyName = request.RNLPropertyName;
//                dept.IsActive = request.IsActive;
//                var result = await _unitofWork.RNLPropertys.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

