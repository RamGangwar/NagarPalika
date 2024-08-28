using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.RNLArrears
{
    public class UpdateRNLArrearHandler : IRequestHandler<UpdateRNLArrearCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdateRNLArrearHandler> _logger;
        public UpdateRNLArrearHandler(IUnitofWork unitofWork, ILogger<UpdateRNLArrearHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }
        public async Task<ResponseModel> Handle(UpdateRNLArrearCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {RNLArrearName = request.RNLArrearName, RNLArrearId_neq = request.RNLArrearId };
//            var deptDuplicate = await _unitofWork.RNLArrears.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "RNLArrear Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.RNLArrears.GetById(request.RNLArrearId);
//            if (dept != null && dept.RNLArrearId > 0)
//            {
//                dept.RNLArrearName = request.RNLArrearName;
//                dept.IsActive = request.IsActive;
//                var result = await _unitofWork.RNLArrears.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

