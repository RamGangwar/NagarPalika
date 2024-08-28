using MediatR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.AssetSubCategorys
{
    public class DeleteAssetSubCategoryHandler : IRequestHandler<DeleteAssetSubCategoryCommand, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<DeleteAssetSubCategoryHandler> _logger;

        public DeleteAssetSubCategoryHandler(IUnitofWork unitofWork, ILogger<DeleteAssetSubCategoryHandler> logger)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        public async Task<ResponseModel> Handle(DeleteAssetSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(Handle), request);
            var dept = await _unitofWork.AssetSubCategorys.GetById(request.AssetSubCategoryId);
            if (dept != null && dept.AssetSubCategoryId > 0)
            {
                var res = await _unitofWork.AssetSubCategorys.Delete(dept);
                return new ResponseModel { Message = "Delete Successfully", Succeeded = true };
            }
            return new ResponseModel { Message = "AssetSubCategory Not Found", Succeeded=false };
        }
    }
}

