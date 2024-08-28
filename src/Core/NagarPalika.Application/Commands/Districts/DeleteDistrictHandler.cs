using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Districts
{
    public class DeleteDistrictHandler : IRequestHandler<DeleteDistrictCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteDistrictHandler> _logger;

        public DeleteDistrictHandler(IUnitofWork unitofWork, ILogger<DeleteDistrictHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.Districts.GetById(request.DistrictId);
            if (dept != null && dept.DistrictId > 0)
            {
                var res = await _unitofWork.Districts.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "District Not Found", Succeeded=false };
        }
    }
}

