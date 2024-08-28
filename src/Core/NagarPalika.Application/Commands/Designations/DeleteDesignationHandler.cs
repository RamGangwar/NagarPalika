using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Designations
{
    public class DeleteDesignationHandler : IRequestHandler<DeleteDesignationCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDesignationHandler> _logger;


        public DeleteDesignationHandler(IUnitofWork unitofWork, ILogger<DeleteDesignationHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Designations.GetById(request.DesignationId);
            if (dept != null && dept.DesignationId > 0)
            {
                var res = await _unitofWork.Designations.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Department Not Found", Succeeded=false };
        }
    }
}
