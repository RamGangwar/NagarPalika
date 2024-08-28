using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Ward
{
    public class DeleteWardsHandler : IRequestHandler<DeleteWardsCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteWardsHandler> _logger;


        public DeleteWardsHandler(IUnitofWork unitofWork, ILogger<DeleteWardsHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteWardsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Wards.GetById(request.WardId);
            if (dept != null && dept.WardId > 0)
            {
                var res = await _unitofWork.Wards.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded=true };
            }
            return new ResponseModel { Message = "Ward Not Found", Succeeded=false };
        }
    }
}
