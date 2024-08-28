using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.PosessonModes
{
    public class UpdatePosessonModeHandler : IRequestHandler<UpdatePosessonModeCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<UpdatePosessonModeHandler> _logger;
        public UpdatePosessonModeHandler(IUnitofWork unitofWork, ILogger<UpdatePosessonModeHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }
        public async Task<ResponseModel> Handle(UpdatePosessonModeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
//            var query = new {PosessonModeName = request.PosessonModeName, PosessonModeId_neq = request.PosessonModeId };
//            var deptDuplicate = await _unitofWork.PosessonModes.GetByClause(query);
//            if (deptDuplicate != null)
//            {
//                return new ResponseModel {Message = "PosessonMode Already Exists",Succeeded=false};
//            }
//            var dept = await _unitofWork.PosessonModes.GetById(request.PosessonModeId);
//            if (dept != null && dept.PosessonModeId > 0)
//            {
//                dept.PosessonModeName = request.PosessonModeName;
//                dept.IsActive = request.IsActive;
//                var result = await _unitofWork.PosessonModes.Update(dept);
//                if (result)
//                {
//                    return new ResponseModel {Message = "Updated Successfully",Succeeded=true};
//                }
//            }
            return new ResponseModel {Message = "Failed to update",Succeeded=false};
        }
    }
}

