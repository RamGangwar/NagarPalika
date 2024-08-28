using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.AssetCategorys
{
    public class DeleteAssetCategoryHandler : IRequestHandler<DeleteAssetCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteAssetCategoryHandler> _logger;

        public DeleteAssetCategoryHandler(IUnitofWork unitofWork, ILogger<DeleteAssetCategoryHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteAssetCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.AssetCategorys.GetById(request.AssetCategoryId);
            if (dept != null && dept.AssetCategoryId > 0)
            {
                var res = await _unitofWork.AssetCategorys.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "AssetCategory Not Found", Succeeded=false };
        }
    }
}

